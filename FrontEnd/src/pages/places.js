import React, { Fragment, Component } from 'react';
import Layout from '../layouts/UserLayout';
import Grid from '@material-ui/core/Grid';
import Popup from "reactjs-popup";
import DayPicker from 'react-day-picker';
import { makeStyles } from '@material-ui/core/styles';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import DateFnsUtils from '@date-io/date-fns'; // choose your lib
import {
    DatePicker,
    TimePicker,
    DateTimePicker,
    MuiPickersUtilsProvider,
} from '@material-ui/pickers';

import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import ScheduleIcon from '@material-ui/icons/Schedule';

// Or import the input component
import DayPickerInput from 'react-day-picker/DayPickerInput';

import 'react-day-picker/lib/style.css';

//table
import MaterialTable from 'material-table';
import CancelIcon from '@material-ui/icons/Cancel';
import AddCircleIcon from '@material-ui/icons/AddCircle';
import tableStyle from '../styles/table.css'
import TableContainer from '@material-ui/core/TableContainer';

//map
import MapSection from '../components/map/Map';

//Data & time picker
import DatetimeRangePicker from 'react-datetime-range-picker';

import { Container } from '@material-ui/core';

import Button from '@material-ui/core/Button';

//style
import '../styles/classes.css';

//webAPI
import { checkAuthentication, validateAuth, checkPlacesPage, checkRentPlace, checkRefundRent, checkAvailabilityPlace } from '../components/WebAPI';
import { validUser } from './user';


const values1 = [
    { id: 'Gym', title: 'Braga', priority: 170, type: 20, complete: '20', incomplete: 'Sunny', begin: '2018-12-13T00:03', end: '2018-12-16T23:29', lat: 41.5518, lng: -8.4229 },
    { id: 'Tennis court', title: 'Guimarães', priority: 100, type: 15, complete: '10', incomplete: 'Rainy', begin: '14:00', end: '16:00', lat: 41.4418, lng: -8.29563 },
    { id: 'Basketball court', title: 'Viana do Castelo', priority: 120, type: 12, complete: '15', incomplete: 'Cloudy', begin: '10:00', end: '12:00', lat: 41.5518, lng: -8.4229 }
];

const entredatas = [
    { id: 'Gym', begin: '14:00', end: '16:00' },
    { id: 'Gym', begin: '17:00', end: '18:00' },
    { id: 'Gym', begin: '19:30', end: '21:00' },

];

const showcolumns = [
    { title: "Place", field: "local" },
    { title: "Type", field: "tipo" },
    { title: "Price", field: "precoHora", type: "currency" },
    { title: "Capacity", field: "lotacao", type: "numeric" },
    { title: "Begin", field: "disponivelIni", type: "datetime" },
    { title: "End", field: "disponivelFim", type: "datetime" }
];

class Places extends Component {
    constructor(props) {
        super(props);
        this.handleDayClick = this.handleDayClick.bind(this);
        this.handleTimeBeginChange = this.handleTimeBeginChange.bind(this);
        this.handleTimeEndChange = this.handleTimeEndChange.bind(this);
        this.state = {
            data: {
                rented: [],
                toRent: [],
                flag: null
            },
            alreadyLogged: 'loading',
            selectedDay: Date.now(),
            selectedTimeBegin: Date.now(),
            selectedTimeEnd: Date.now(),
            selectedRow: null,
            occupied: []
        }
    }

    async componentWillMount() {
        await checkPlacesPage(this);
        await checkAuthentication(this);
    }

    async handleDayClick(day) {
        this.setState({
            selectedDay: day
        });
        this.setState({
            occupied: await checkAvailabilityPlace(this, this.state.selectedRow, new Date(day).toISOString())
        });
    }

    handleTimeBeginChange(time) {
        this.setState({
            selectedTimeBegin: time
        });
        console.log(time)
    }

    handleTimeEndChange(time) {
        this.setState({
            selectedTimeEnd: time
        });
        console.log(time)
    }

    render() {
        if (this.state.alreadyLogged !== validUser) return validateAuth(this, validUser);

        return (
            <Layout>
                <h2 style={{ margin: '35px 5px 5px 75px', color: '#85D8CE' }}>Next appointments</h2>
                <MaterialTable
                    actions={[
                        {
                            icon: CancelIcon,
                            tooltip: 'Cancel',
                            onClick: (event, rowData) => {
                                checkRefundRent(this,
                                    rowData.codEspaco,
                                    rowData.disponivelIni,
                                    rowData.disponivelFim
                                );
                            }
                        }
                    ]}
                    columns={showcolumns}
                    data={this.state.data.rented}
                    title=""
                />
                <h2 style={{ margin: '35px 5px 5px 75px', color: '#85D8CE' }}>Available places</h2>
                <MaterialTable
                    style={tableStyle}
                    columns={showcolumns}
                    data={this.state.data.toRent}
                    title=""
                    onRowClick={(event, rowData) => {
                        this.setState({
                            selectedRow: rowData.codEspaco
                        });
                    }}
                    detailPanel={rowData => {
                        var b = Date.now();
                        var e = Date.now();
                        return (
                            <Grid
                                container
                                direction="row"
                                justify="center"
                                alignItems="center"
                            >
                                <Grid item xs={10}>
                                    <MapSection
                                        location={{
                                            address: rowData.tipo,
                                            lat: rowData.lat,
                                            lng: rowData.lng,
                                        }}
                                        zoomLevel={17}
                                    />
                                </Grid>
                                <Grid item xs={2}>
                                    <Container maxWidth="sm">
                                        <Popup
                                            modal
                                            style={{ padding: '10' }}
                                            trigger={
                                                <Button style={{ padding: '10' }} variant="outlined">
                                                    Rent Space
                                                </Button>
                                            }
                                            position="center">
                                            <Grid
                                                container
                                                direction="row"
                                                justify="center"
                                                alignItems="center"
                                            >
                                                <DayPicker
                                                    showOutsideDays
                                                    todayButton="Today"
                                                    selectedDays={this.state.selectedDay}
                                                    onDayClick={this.handleDayClick}
                                                />
                                                <Grid item xs={12}>
                                                    <Popup
                                                        modal
                                                        trigger={
                                                            <Button variant="outlined" onClick={() => {
                                                                this.setState({
                                                                    selectedRow: rowData.codEspaco
                                                                });
                                                            }}>
                                                                Chose Time Interval
                                                        </Button>
                                                        }
                                                        position="center">
                                                        <Grid
                                                            container
                                                            direction="row"
                                                            justify="center"
                                                            alignItems="center"
                                                        >
                                                            <Grid item xs={12}>
                                                                <MaterialTable
                                                                    columns={[
                                                                        { title: "Begin", field: "dateBegin", type: "time" },
                                                                        { title: "End", field: "dateEnd", type: "time" }]}
                                                                    data={this.state.occupied}
                                                                    title="Busy Hours"
                                                                />
                                                            </Grid>
                                                            <Grid item xs={12} >
                                                                <div
                                                                    style={{
                                                                        display: "flex",
                                                                        justifyContent: "center",
                                                                        alignItems: "center"
                                                                    }}
                                                                >
                                                                    <MuiPickersUtilsProvider utils={DateFnsUtils}>
                                                                        <TimePicker value={this.state.selectedTimeBegin} onChange={this.handleTimeBeginChange} helperText={''} />
                                                                        <TimePicker value={this.state.handleTimeEndChange} onChange={this.handleTimeEndChange} helperText={''} />
                                                                    </MuiPickersUtilsProvider>
                                                                </div>
                                                            </Grid>
                                                            <Grid item xs={12}>
                                                                <Button onClick={() => {
                                                                    var fy = new Date(this.state.selectedDay);

                                                                    var db = new Date(this.state.selectedTimeBegin);

                                                                    var de = new Date(this.state.selectedTimeEnd);

                                                                    db.setFullYear(2020);
                                                                    db.setMonth(fy.getMonth());
                                                                    db.setDate(fy.getDate());

                                                                    de.setFullYear(2020);
                                                                    de.setMonth(fy.getMonth());
                                                                    de.setDate(fy.getDate());



                                                                    if (db < de && fy >= Date.now())
                                                                        checkRentPlace(this, 
                                                                            rowData.codEspaco,
                                                                            db.toISOString(),
                                                                            de.toISOString()
                                                                        );
                                                                    else alert("Wrong Dates.");
                                                                }}>Confirm</Button>
                                                            </Grid>
                                                        </Grid>
                                                    </Popup>
                                                </Grid>
                                            </Grid>
                                        </Popup>
                                    </Container>
                                </Grid>
                            </Grid>
                        )
                    }}
                />
            </Layout>
        );
    }
}

export default Places;