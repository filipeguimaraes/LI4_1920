import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';

import '../styles/classes.css';

import { checkAuthentication, validateAuth } from '../components/WebAPI';
import { validUser } from './user';

import TableClasses from '../components/TableClasses';


const values1 = [
    { id: 'Aerobics', title: 'Gym', priority: 2.90, type: '20', complete: '12:00', incomplete: '13:00' },
    { id: 'Cycling', title: 'Gym', priority: 1.25, type: '15', complete: '16:00', incomplete: '17:00' },
    { id: 'Tennis', title: 'Tennis court', priority: 2.35, type: '6', complete: '18:00', incomplete: '20:00' }
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
                <h2 style={{ margin: '35px 0px 0px 75px', color: '#85D8CE' }}>Next classes</h2>
                <TableClasses data={this.state.data} toRemove={true} />
                <h2 style={{ margin: '35px 0px 0px 75px', color: '#85D8CE' }}>Available classes</h2>
                <TableClasses data={this.state.data} toRemove={false} />
            </Layout>
        );
    }
}

export default Classes;