import React from 'react';
import { Bar, Doughnut, Pie, HorizontalBar } from 'react-chartjs-2';
import { Grid, Cell } from 'react-mdl';

import Layout from '../layouts/UserLayout';

const dataVerticalBar = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
    datasets: [
        {
            label: 'Money spent',
            backgroundColor: '#96DEDA',
            borderColor: '#96DEDA',
            borderWidth: 1,
            hoverBackgroundColor: 'rgb(109, 204, 199)',
            hoverBorderColor: 'rgb(109, 204, 199)',
            data: [65, 59, 80, 81, 56, 55, 40, 60, 43, 32, 67, 42]
        }
    ]
};

const dataDoughnut = {
    labels: [
        'Basketball classes',
        'Tennis classes',
        'Cycling classes',
        'Volleyball classes',
        'Swimming classes'
    ],
    datasets: [{
        data: [30, 50, 10, 15, 25],
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

const dataPie = {
    labels: [
        'Tennis court',
        'Basketball court',
        'Running track'
    ],
    datasets: [{
        data: [30, 50, 15],
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

const dataHorizontalBar = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
    datasets: [
        {
            label: 'Weight',
            backgroundColor: '#96DEDA',
            borderColor: '#96DEDA',
            borderWidth: 1,
            hoverBackgroundColor: 'rgb(109, 204, 199)',
            hoverBorderColor: 'rgb(109, 204, 199)',
            data: [120, 113, 99, 91, 87, 83, 79, 72, 67, 65, 65, 65]
        }
    ]
};

const Statistics = () => (
    <Layout>
        <Grid>
            <Cell col={6} style={{padding:'5em'}}>
                <Bar
                    data={dataVerticalBar}
                    options={{
                        maintainAspectRatio: true
                    }}
                />
            </Cell>
            <Cell col={6} style={{padding:'5em'}}>
                <Doughnut data={dataDoughnut} />
            </Cell>
            <Cell col={6} style={{padding:'5em'}}>
                <Pie data={dataPie} />
            </Cell>
            <Cell col={6} style={{padding:'5em'}}> 
                <HorizontalBar data={dataHorizontalBar} />
            </Cell>
        </Grid>
    </Layout>
);

export default Statistics;