import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';
import Grid from '@material-ui/core/Grid';

//table
import MaterialTable from 'material-table';
import CancelIcon from '@material-ui/icons/Cancel';
import tableStyle from '../styles/table.css'

//map
import MapSection from '../components/map/Map';

//Data & time picker
import DatetimeRangePicker from 'react-datetime-range-picker';

import { Container } from '@material-ui/core';

import Button from '@material-ui/core/Button';

//style
import '../styles/classes.css';

//webAPI
import { checkAuthentication, validateAuth, checkPlacesPage, checkRentPlace, checkRefundRent } from '../components/WebAPI';
import { validUser } from './user';


const values1 = [
    { id: 'Gym', title: 'Braga', priority: 170, type: 20, complete: '20', incomplete: 'Sunny', begin: '2018-12-13T00:03', end: '2018-12-16T23:29', lat: 41.5518, lng: -8.4229 },
    { id: 'Tennis court', title: 'Guimarães', priority: 100, type: 15, complete: '10', incomplete: 'Rainy', begin: '14:00', end: '16:00', lat: 41.4418, lng: -8.29563 },
    { id: 'Basketball court', title: 'Viana do Castelo', priority: 120, type: 12, complete: '15', incomplete: 'Cloudy', begin: '10:00', end: '12:00', lat: 41.5518, lng: -8.4229 }
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

        this.state = {
            data: {
                rented: [],
                toRent: [],
                flag: null
            },
            alreadyLogged: 'loading'
        }
    }

    async componentWillMount() {
        await checkPlacesPage(this);
        await checkAuthentication(this);
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
                                <Grid item xs={8}>
                                    <MapSection
                                        location={{
                                            address: rowData.id,
                                            lat: rowData.lat,
                                            lng: rowData.lng,
                                        }}
                                        zoomLevel={17}
                                    />
                                </Grid>
                                <Grid item xs={4}>
                                    <Container maxWidth="85%">
                                        <DatetimeRangePicker
                                            startDate={Date.now()}
                                            endDate={Date.now()}
                                            isValidStartDate={
                                                (currentDate, selectedDate) => {
                                                    if (currentDate < Date.now())
                                                        return false;
                                                    else return true;
                                                }
                                            }
                                            onStartDateChange={
                                                (date) => {
                                                    b = date;
                                                }
                                            }
                                            onEndDateChange={
                                                (date) => {
                                                    e = date;
                                                }
                                            }
                                        />
                                        <Button
                                            style={{ padding: '10' }}
                                            variant="outlined"
                                            onClick={
                                                async () => {
                                                    await checkRentPlace(this,
                                                        rowData.codEspaco,
                                                        b.toISOString(),
                                                        e.toISOString()
                                                    );
                                                }
                                            }
                                        >
                                            Rent Space
                                        </Button>
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