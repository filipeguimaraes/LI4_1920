import React, { Component } from 'react';
import { DataTable, TableHeader, Grid, Cell, FABButton, Icon } from 'react-mdl';
import '../styles/instructor.css';

import instructorLogo from '../images/instructor.jpg';

import Layout from '../layouts/AuthenticatedLayout';
import Chart from '../components/Chart.js';


class Instructor extends Component {
    constructor() {
        super();
        this.state = {
            chartData: {}
        }
    }

    componentWillMount() {
        this.getChartData();
    }

    getChartData() {
        // Ajax calls here
        this.setState({
            chartData: {
                labels: ['Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto'],
                datasets: [
                    {
                        label: 'Income',
                        data: [
                            700,
                            800,
                            933,
                            1024,
                            5000,
                            4099
                        ],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.6)',
                            'rgba(54, 162, 235, 0.6)',
                            'rgba(255, 206, 86, 0.6)',
                            'rgba(75, 192, 192, 0.6)',
                            'rgba(153, 102, 255, 0.6)',
                            'rgba(255, 159, 64, 0.6)',
                            'rgba(255, 99, 132, 0.6)'
                        ]
                    }
                ]
            }
        });
    }
    render() {
        return (
            <Layout>
                <div style={{ width: '80%', margin: 'auto' }}>
                    <Grid className="profile-instructor">
                        <Cell col={4} style={{ align: 'center', margin: 'auto' }}>
                            <div>
                                <img
                                    src={instructorLogo}
                                    alt="Imagem"
                                    className="profile-instructor-img"
                                />
                                <h3 style={{ color: '#85D8CE', textAlign: "center" }}>Hi! Instructor</h3>
                            </div>
                        </Cell>
                        <Cell col={8} style={{ margin: 'auto' }}>
                            <Chart chartData={this.state.chartData} />
                        </Cell>
                    </Grid>
                    <Grid >
                        <Cell col={8} style={{ margin: 'auto', align: 'center' }}>
                            <DataTable
                                className="table-instructor"
                                align='center'
                                shadow={0}
                                rows={[
                                    { class: 'Aerobics', quantity: 'Gym', price: 2.90, capacity: '20', begin: '12:00', end: '13:00' },
                                    { class: 'Cycling', quantity: 'Gym', price: 1.25, capacity: '15', begin: '16:00', end: '17:00' },
                                    { class: 'Tennis', quantity: 'Tennis court', price: 2.35, capacity: '6', begin: '18:00', end: '20:00' }
                                ]}
                            >
                                <TableHeader name="class" >Class</TableHeader>
                                <TableHeader name="quantity" >Place</TableHeader>
                                <TableHeader name="price" cellFormatter={(price) => `$${price.toFixed(2)}`} >Price</TableHeader>
                                <TableHeader name="capacity" >Capacity</TableHeader>
                                <TableHeader name="begin" >Begin</TableHeader>
                                <TableHeader name="end" >End</TableHeader>
                            </DataTable>

                        </Cell>
                        <Cell col={4} style={{ margin: 'auto', align: 'center' }}>
                            <Grid >
                                <Cell col={12}>
                                    <FABButton mini style={{ color: '#85D8CE', textAlign: "center" }}>
                                        <Icon name="add" />
                                    </FABButton> New Class
                                </Cell>
                            </Grid>
                            <Grid >
                                <Cell col={12}>
                                    <FABButton mini style={{ color: '#85D8CE', textAlign: "center" }}>
                                        <Icon name="cancel" />
                                    </FABButton> Cancel Class
                                </Cell>
                            </Grid>
                            <Grid >
                                <Cell col={12}>
                                    <FABButton mini style={{ color: '#85D8CE', textAlign: "center" }}>
                                        <Icon name="history" />
                                    </FABButton> See History
                                </Cell>
                            </Grid>
                        </Cell>
                    </Grid>
                </div>
            </Layout>
        );
    }
}

export default Instructor;
