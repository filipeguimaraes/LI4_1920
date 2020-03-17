import React, { Component } from 'react';

import { Cell, Grid } from 'react-mdl';
import DatePicker from "react-datepicker";
import Layout from '../layouts/AuthenticatedLayout';
import "react-datepicker/dist/react-datepicker.css";


class NewClass extends Component {
    state = {
        startDate: new Date(),
        endDate: new Date()
    };

    handleStartDate = startdate => {
        this.setState({
            startDate: startdate
        });
    };

    handleEndDate = enddate => {
        this.setState({
            endDate: enddate
        });
    };

    render() {
        return (
            <Layout>
                <div style={{ width: '80%', margin: 'auto' }}>
                    <h1>New Class</h1>
                    <form method="post" action="form.php">
                        <Grid >
                            <Cell col={12} style={{ margin: '0 auto' }}>
                                <div>
                                    <label for="Modality">Modality</label>
                                    <input type="text" name="modality" />
                                </div>
                            </Cell>
                        </Grid>
                        <Grid style={{ margin: '0 auto' }}>
                            <Cell col={6} style={{ margin: '0 auto' }}>
                                <div>
                                    <label for="Tickets">Tickets</label>
                                    <input type="number" name="tickets" />
                                </div>
                            </Cell>
                            <Cell col={6} style={{ margin: '0 auto' }}>
                                <div>
                                    <label for="price">Price</label>
                                    <input type="price" name="price" />
                                </div>
                            </Cell>
                        </Grid>
                        <Grid style={{ margin: '0 auto' }}>
                            <Cell col={6} style={{ margin: '0 auto' }}>
                                <div>
                                    <div>Start</div>
                                    <DatePicker
                                        selected={this.state.startDate}
                                        onChange={this.handleStartDate}
                                        showTimeSelect
                                        dateFormat="Pp"
                                    />
                                </div>
                            </Cell>
                            <Cell col={6} style={{ margin: '0 auto' }}>
                                <div>
                                    <div>End</div>
                                    <DatePicker
                                        selected={this.state.endDate}
                                        onChange={this.handleEndDate}
                                        showTimeSelect
                                        dateFormat="Pp"
                                    />
                                </div>
                            </Cell>
                        </Grid>
                        <button type="create">Create</button>
                    </form>
                </div>
            </Layout>
        );
    }
}

export default NewClass;