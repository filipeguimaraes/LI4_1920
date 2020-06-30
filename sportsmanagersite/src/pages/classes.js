import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';


import MaterialTable from 'material-table';
import CancelIcon from '@material-ui/icons/Cancel';
import ControlPointIcon from '@material-ui/icons/ControlPoint';

import '../styles/classes.css';

import { checkAuthentication, validateAuth } from '../components/WebAPI';
import { validUser } from './user';

//import TableClasses from '../components/TableClasses';


const values1 = [
    { id: 'Aerobics', title: 'Gym', priority: 2.90, type: '20', complete: '12:00', incomplete: '13:00' },
    { id: 'Cycling', title: 'Gym', priority: 1.25, type: '15', complete: '16:00', incomplete: '17:00' },
    { id: 'Tennis', title: 'Tennis court', priority: 2.35, type: '6', complete: '18:00', incomplete: '20:00' }
];

const showcolumns = [
    { title: "Class", field: "id" },
    { title: "Place", field: "title" },
    { title: "Price", field: "priority", type: "currency" },
    { title: "Capacity", field: "type", type: "numeric" },
    { title: "Begin", field: "complete", type: "time" },
    { title: "End", field: "incomplete", type: "time" }
];


class Classes extends Component {
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
                <h2 style={{ margin: '35px 5px 5px 75px', color: '#85D8CE' }}>Next classes</h2>
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

                <h2 style={{ margin: '35px 5px 5px 75px', color: '#85D8CE' }}>Available classes</h2>
                <MaterialTable
                    actions={[
                        {
                            icon: ControlPointIcon,
                            tooltip: 'Cancel Class',
                            onClick: (event, rowData) => {
                                // Do cancel class
                            }
                        }
                    ]}
                    columns={this.showcolumns}
                    data={this.state.data}
                    title=""
                />
            </Layout>
        );
    }
}

export default Classes;