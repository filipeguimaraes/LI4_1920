import React, { Component } from 'react';
import { Bar, Doughnut, Pie, HorizontalBar } from 'react-chartjs-2';
import { Grid, Cell } from 'react-mdl';

import Layout from '../layouts/UserLayout';

import { checkAuthentication, validateAuth } from '../components/WebAPI';
import { validUser } from './user';

const dataVerticalBar = (inData) => {
    return {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
        datasets: [
            {
                label: 'Money spent',
                backgroundColor: '#96DEDA',
                borderColor: '#96DEDA',
                borderWidth: 1,
                hoverBackgroundColor: 'rgb(109, 204, 199)',
                hoverBorderColor: 'rgb(109, 204, 199)',
                data: inData
            }
        ]
    };
}

const dataDoughnut = (inData) => {
    return {
        labels: [
            'Basketball classes',
            'Tennis classes',
            'Cycling classes',
            'Volleyball classes',
            'Swimming classes'
        ],
        datasets: [{
            data: inData,
            backgroundColor: [
                'rgb(132, 202, 199)',
                'rgb(14, 129, 145)',
                'rgb(102, 206, 201)',
                'rgb(52, 194, 187)',
                'rgb(136, 230, 225)'
            ],
            hoverBackgroundColor: [
                'rgb(132, 202, 199)',
                'rgb(14, 129, 145)',
                'rgb(102, 206, 201)',
                'rgb(52, 194, 187)',
                'rgb(136, 230, 225)'
            ]
        }]
    };
}

const dataPie = (inData) => {
    return {
        labels: [
            'Tennis court',
            'Basketball court',
            'Running track'
        ],
        datasets: [{
            data: inData,
            backgroundColor: [
                'rgb(132, 202, 199)',
                'rgb(14, 129, 145)',
                'rgb(52, 194, 187)'
            ],
            hoverBackgroundColor: [
                'rgb(132, 202, 199)',
                'rgb(14, 129, 145)',
                'rgb(52, 194, 187)'
            ]
        }]
    };
}

const dataHorizontalBar = (inData) => {
    return {
        labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
        datasets: [
            {
                label: 'Weight',
                backgroundColor: '#96DEDA',
                borderColor: '#96DEDA',
                borderWidth: 1,
                hoverBackgroundColor: 'rgb(109, 204, 199)',
                hoverBorderColor: 'rgb(109, 204, 199)',
                data: inData
            }
        ]
    };
}

class Statistics extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            alreadyLogged: 'loading'
        }
    }

    async componentWillMount() {
        await checkAuthentication(this);
    }

    render() {
        if (this.state.alreadyLogged !== validUser) return validateAuth(this, validUser);

        return (
            <Layout>
                <Grid>
                    <Cell col={6} style={{ margin: 'auto' }}>
                        <Bar
                            data={dataVerticalBar([65, 59, 80, 81, 56, 55, 40, 60, 43, 32, 67, 42])}
                            options={{
                                maintainAspectRatio: true
                            }}
                        />
                    </Cell>
                    <Cell col={6} style={{ margin: 'auto' }}>
                        <Doughnut data={dataDoughnut([30, 50, 10, 15, 25])} />
                    </Cell>
                    <Cell col={6} style={{ margin: 'auto' }}>
                        <Pie data={dataPie([30, 50, 15])} />
                    </Cell>
                    <Cell col={6} style={{ margin: 'auto' }}>
                        <HorizontalBar data={dataHorizontalBar([120, 113, 99, 91, 87, 83, 79, 72, 67, 65, 65, 65])} />
                    </Cell>
                </Grid>
            </Layout>
        );
    }
}

export default Statistics;