import React, { Component } from 'react';
import { Grid, Cell } from 'react-mdl';
import '../styles/instructor.css';

import userLogo from '../images/marcelo.jpg';

import MaterialTable from 'material-table';
import { AddBox, ArrowDownward } from "@material-ui/icons";

import Layout from '../layouts/InstructorLayout';
import Chart from '../components/Chart.js';

import { checkAuthentication, validateAuth } from '../components/WebAPI';


export const validInstructor = 'instructor';

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
            alreadyLogged: 'loading'
        }
    }

    async componentWillMount() {
        this.getChartData();
        this.getClassesData();
        await checkAuthentication(this);
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
                                <h3 style={{ color: '#85D8CE', textAlign: "center" }}>Welcome,  John!</h3>
                            </div>
                        </Cell>
                        <Cell col={8} style={{ margin: 'auto' }}>
                            <Chart chartData={this.state.chartData} />
                        </Cell>
                    </Grid>



                </div>
                <div>
                    <MaterialTable
                        options={
                            { showTitle: false },
                            { actionsColumnIndex: -1 }
                        }
                        title=""
                        columns={[
                            { title: "Class", field: "id" },
                            { title: "Place", field: "title" },
                            { title: "Price", field: "priority", type: "currency" },
                            { title: "Capacity", field: "type", type: "numeric" },
                            { title: "Begin", field: "complete", type: "time" },
                            { title: "End", field: "incomplete", type: "time" }
                        ]}
                        data={this.state.classes}
                        editable={{
                            onRowAdd: newData =>
                                new Promise((resolve, reject) => {
                                    setTimeout(() => {
                                        /* setData([...data, newData]); */

                                        resolve();
                                    }, 1000);
                                }),
                            onRowUpdate: (newData, oldData) =>
                                new Promise((resolve, reject) => {
                                    setTimeout(() => {
                                        {
                                            const data = this.state.data;
                                            const index = data.indexOf(oldData);
                                            data[index] = newData;
                                            this.setState({ data }, () => resolve());
                                        }
                                        resolve()
                                    }, 1000)
                                }),
                            onRowDelete: (newData, oldData) =>
                            new Promise((resolve, reject) => {
                                setTimeout(() => {
                                    {
                                        const data = this.state.data;
                                        const index = data.indexOf(oldData);
                                        data[index] = newData;
                                        this.setState({ data }, () => resolve());
                                    }
                                    resolve()
                                }, 1000)
                            })
                        }}
                    />
                </div>
            </Layout>

        );
    }
}

export default Instructor;