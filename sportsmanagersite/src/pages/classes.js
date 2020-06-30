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
    { modalidade: 'Aerobics', codEspaco: 'Gym', precoBilhete: 2.90, numBilhetes: '20', dataINI: '12:00', dataFIM: '13:00' },
    { modalidade: 'Cycling', codEspaco: 'Gym', precoBilhete: 1.25, numBilhetes: '15', dataINI: '16:00', dataFIM: '17:00' },
    { modalidade: 'Tennis', codEspaco: 'Tennis court', precoBilhete: 2.35, numBilhetes: '6', dataINI: '18:00', dataFIM: '20:00' }
];

const showcolumns = [
    { title: "Class", field: "modalidade" },
    { title: "Place", field: "codEspaco"},//, type: "numeric" },
    { title: "Price", field: "precoBilhete", type: "currency" },
    { title: "Capacity", field: "numBilhetes", type: "numeric" },
    { title: "Begin", field: "dataINI", type: "datetime" },
    { title: "End", field: "dataFIM", type: "datetime" }
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
                    columns={showcolumns}
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
                    columns={showcolumns}
                    data={this.state.data}
                    title=""
                />
            </Layout>
        );
    }
}

export default Classes;