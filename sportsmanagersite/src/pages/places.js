import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';

import MaterialTable from 'material-table';
import CancelIcon from '@material-ui/icons/Cancel';
import ControlPointIcon from '@material-ui/icons/ControlPoint';

import '../styles/classes.css';

import { checkAuthentication, validateAuth } from '../components/WebAPI';
import { validUser } from './user';



const values1 = [
    { id: 'Gym', title: 'Braga', priority: 170, type: 20, complete: '20', incomplete: 'Sunny', begin: '16:00', end: '18:00' },
    { id: 'Tennis court', title: 'Guimarães', priority: 100, type: 15, complete: '10', incomplete: 'Rainy', begin: '14:00', end: '16:00' },
    { id: 'Basketball court', title: 'Viana do Castelo', priority: 120, type: 12, complete: '15', incomplete: 'Cloudy', begin: '10:00', end: '12:00' }
];

const showcolumns = [
    { title: "Class", field: "id" },
    { title: "Place", field: "title" },
    { title: "Price", field: "priority", type: "currency" },
    { title: "Capacity", field: "type", type: "numeric" },
    { title: "Begin", field: "complete", type: "time" },
    { title: "End", field: "incomplete", type: "time" }
];

class Places extends Component {
    constructor(props) {
        super(props);

        this.state = {
            data: [],
            alreadyLogged: 'loading'
        }
    }

    async componentWillMount() {
        this.setState({ data: values1 });
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
                            tooltip: 'Enroll Class',
                            onClick: (event, rowData) => {
                                // Do cancel class
                            }
                        }
                    ]}
                    columns={this.showcolumns}
                    data={this.state.data}
                    title=""
                />
                <h2 style={{ margin: '35px 5px 5px 75px', color: '#85D8CE' }}>Available places</h2>
                <MaterialTable
                    columns={this.showcolumns}
                    data={this.state.data}
                    title=""
                    detailPanel={rowData => {
                        return (
                          <iframe
                            width="100%"
                            height="315"
                            src="https://www.youtube.com/embed/C0DPdy98e4c"
                            frameborder="0"
                            allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture"
                            allowfullscreen
                          />
                        )
                      }}
                />
            </Layout>
        );
    }
}

export default Places;