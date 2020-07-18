import React, { Component, forwardRef } from 'react';
import { Grid, Cell } from 'react-mdl';
import '../styles/instructor.css';

import userLogo from '../images/marcelo.jpg';

import { Container } from '@material-ui/core';

import MaterialTable from 'material-table';
import AddBox from "@material-ui/icons/AddBox";
import ArrowDownward from "@material-ui/icons/ArrowDownward";
import { withStyles } from '@material-ui/core/styles';
import tableStyle from '../styles/table.css'
import Check from '@material-ui/icons/Check';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import DeleteOutline from '@material-ui/icons/DeleteOutline';
import Edit from '@material-ui/icons/Edit';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Remove from '@material-ui/icons/Remove';
import SaveAlt from '@material-ui/icons/SaveAlt';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';


import Layout from '../layouts/InstructorLayout';
import Chart from '../components/Chart.js';

import { checkAuthentication, validateAuth, checkInstructor, varsClass, checkAddClass, checkDeleteClass, checkUpdateClass } from '../components/WebAPI';


export const validInstructor = 'instructor';

const tableIcons = {
    Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
    Check: forwardRef((props, ref) => <Check {...props} ref={ref} />),
    Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Delete: forwardRef((props, ref) => <DeleteOutline {...props} ref={ref} />),
    DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
    Export: forwardRef((props, ref) => <SaveAlt {...props} ref={ref} />),
    Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
    FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
    LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
    NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
    PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
    ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
    Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
    SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
    ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
    ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
};

let classesData = [
    { id: 'Aerobics', title: 'Gym', priority: 2.90, type: '20', complete: '12:00', incomplete: '13:00' },
    { id: 'Cycling', title: 'Gym', priority: 1.25, type: '15', complete: '16:00', incomplete: '17:00' },
    { id: 'Tennis', title: 'Tennis court', priority: 2.35, type: '6', complete: '18:00', incomplete: '20:00' }
];

class Instructor extends Component {
    constructor() {
        super();

        this.state = {
            chartData: {},
            classes: [],
            name: 'N/A',
            email: 'N/A',
            alreadyLogged: 'loading'
        }
    }

    async componentWillMount() {
        this.getChartData();
        await checkAuthentication(this);
        await checkInstructor(this);
    }

    getClassesData() {
        this.setState({
            classes: classesData
        })
    }

    changeClass(event) {
        console.log(event);
    }

    saveEditable = (classId) => {
        const newArray = this.state.classes.map((row) => (
            row.id === classId ? { ...row, editable: false }
                :
                row
        ));
        this.setState({ classes: newArray });
    }

    makeEditable = (classId) => {
        const newArray = this.state.classes.map((row) => (
            row.id === classId ? { ...row, editable: true }
                :
                row
        ));
        this.setState({ classes: newArray });
    }

    removeClass = (classId) => {
        const arrayCopy = this.state.classes.filter((row) => row.id !== classId);
        this.setState({ classes: arrayCopy });
    };

    getChartData() {
        // Ajax calls here
        this.setState({
            chartData: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                datasets: [
                    {
                        label: 'Income',
                        data: [
                            700,
                            800,
                            933,
                            965,
                            543,
                            456,
                            768,
                            954,
                            453,
                            964,
                            865,
                            458
                        ],
                        backgroundColor: '#96DEDA'
                    }
                ]
            }
        });
    }

    render() {
        if (this.state.alreadyLogged !== validInstructor) return validateAuth(this, validInstructor);




        return (
            <Layout>
                <div style={{ width: '80%', margin: 'auto' }}>
                    <Grid className="profile-instructor">
                        <Cell col={4} style={{ align: 'center', margin: 'auto' }}>
                            <div>
                                <img
                                    src={userLogo}
                                    alt="Imagem"
                                    className="profile-instructor-img"
                                />
                                <h3 style={{ color: '#85D8CE', textAlign: "center" }}>Welcome,  {this.state.name}!</h3>
                            </div>
                        </Cell>
                        <Cell col={8} style={{ margin: 'auto' }}>
                            <Chart chartData={this.state.chartData} />
                        </Cell>
                    </Grid>
                </div>
                <Container maxWidth="85%">
                    <MaterialTable
                        icons={tableIcons}
                        options={
                            { showTitle: false },
                            { actionsColumnIndex: -1 }
                        }
                        title=""
                        columns={[
                            { title: "Class", field: "modalidade" },
                            { title: "Place", field: "codEspaco", type: "numeric" },
                            { title: "Price", field: "precoBilhete", type: "currency" },
                            { title: "Capacity", field: "numBilhetes", type: "numeric" },
                            { title: "Begin", field: "dataINI", type: "datetime" },
                            { title: "End", field: "dataFIM", type: "datetime" }
                        ]}
                        data={this.state.classes}
                        editable={{
                            onRowAdd: newData =>
                                new Promise((resolve, reject) => {
                                    setTimeout(() => {

                                        varsClass(
                                            newData.numBilhetes,
                                            newData.precoBilhete,
                                            new Date(newData.dataINI).toISOString(),
                                            new Date(newData.dataFIM).toISOString(),
                                            newData.modalidade,
                                            this.state.email,
                                            newData.codEspaco,
                                            'addClass'
                                        );

                                        checkAddClass(this);

                                        resolve();
                                    }, 1000);
                                }),
                            onRowUpdate: (newData, oldData) =>
                                new Promise((resolve, reject) => {
                                    setTimeout(() => {
                                        {
                                            varsClass(
                                                parseInt(newData.numBilhetes),
                                                newData.precoBilhete,
                                                new Date(newData.dataINI).toISOString(),
                                                new Date(newData.dataFIM).toISOString(),
                                                newData.modalidade,
                                                this.state.email,
                                                parseInt(newData.codEspaco),
                                                'updateClass'
                                            );

                                            checkUpdateClass(this, newData.codAula);
                                        }
                                        resolve()
                                    }, 1000)
                                }),
                            onRowDelete: (newData, oldData) =>
                                new Promise((resolve, reject) => {
                                    setTimeout(() => {
                                        {
                                            checkDeleteClass(this, newData.codAula);
                                            console.log(newData);
                                        }
                                        resolve()
                                    }, 1000)
                                })
                        }}
                    />
                </Container>
            </Layout>

        );
    }
}

export default Instructor;