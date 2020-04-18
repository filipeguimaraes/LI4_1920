import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';

import '../styles/classes.css';

import { checkAuthentication, validateAuth } from '../components/WebAPI';
import { validUser } from './user';

import TablePlaces from '../components/TablePlaces';


const values1 = [
    { id: 'Gym', title: 'Braga', priority: 170, type: 20, complete: '20', incomplete: 'Sunny', begin: '16:00', end: '18:00' },
    { id: 'Tennis court', title: 'Guimarães', priority: 100, type: 15, complete: '10', incomplete: 'Rainy', begin: '14:00', end: '16:00' },
    { id: 'Basketball court', title: 'Viana do Castelo', priority: 120, type: 12, complete: '15', incomplete: 'Cloudy', begin: '10:00', end: '12:00' }
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
                <h2 style={{ margin: '35px 0px 0px 75px', color: '#85D8CE' }}>Next appointments</h2>
                <TablePlaces data={this.state.data} toRemove={true} />
                <h2 style={{ margin: '35px 0px 0px 75px', color: '#85D8CE' }}>Available places</h2>
                <TablePlaces data={this.state.data} toRemove={false} />
            </Layout>
        );
    }
}

export default Places;