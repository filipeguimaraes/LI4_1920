import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';

//table
import MaterialTable from 'material-table';
import CancelIcon from '@material-ui/icons/Cancel';

//map
import MapSection from '../components/map/Map'

//style
import '../styles/classes.css';

//webAPI
import { checkAuthentication, validateAuth } from '../components/WebAPI';
import { validUser } from './user';

const location = {
    address: '1600 Amphitheatre Parkway, Mountain View, california.',
    lat: 37.42216,
    lng: -122.08427,
} // our location object from earlier

const values1 = [
    { id: 'Gym', title: 'Braga', priority: 170, type: 20, complete: '20', incomplete: 'Sunny', begin: '16:00', end: '18:00', lat: 41.5518, lng: -8.4229 },
    { id: 'Tennis court', title: 'Guimarães', priority: 100, type: 15, complete: '10', incomplete: 'Rainy', begin: '14:00', end: '16:00', lat: 41.5518, lng: -8.4229 },
    { id: 'Basketball court', title: 'Viana do Castelo', priority: 120, type: 12, complete: '15', incomplete: 'Cloudy', begin: '10:00', end: '12:00', lat: 41.5518, lng: -8.4229 }
];

const showcolumns = [
    { title: "Class", field: "id" },
    { title: "Place", field: "title" },
    { title: "Price", field: "priority", type: "currency" },
    { title: "Capacity", field: "type", type: "numeric" },
    { title: "Begin", field: "begin", type: "time" },
    { title: "End", field: "end", type: "time" }
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
                    columns={showcolumns}
                    data={this.state.data}
                    title=""
                />
                <h2 style={{ margin: '35px 5px 5px 75px', color: '#85D8CE' }}>Available places</h2>
                <MaterialTable
                    columns={showcolumns}
                    data={this.state.data}
                    title=""
                    detailPanel={rowData => {
                        return (
                            <div>
                                <MapSection
                                    location={{
                                        address: rowData.id,
                                        lat: rowData.lat,
                                        lng: rowData.lng,
                                    }}
                                    zoomLevel={17}
                                />
                            </div>
                        )
                    }}
                />
            </Layout>
        );
    }
}

export default Places;