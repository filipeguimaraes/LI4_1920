import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash, faPlusCircle } from '@fortawesome/free-solid-svg-icons'

import '../styles/classes.css';

const values1 = [
    { id: 'Gym', title: 'Braga', priority: 170, type: 20, complete: '20', incomplete: 'Sunny', begin:'16:00', end:'18:00' },
    { id: 'Tennis court', title: 'Guimarães', priority: 100, type: 15, complete: '10', incomplete: 'Rainy' , begin:'14:00', end:'16:00' },
    { id: 'Basketball court', title: 'Viana do Castelo', priority: 120, type: 12, complete: '15', incomplete: 'Cloudy' , begin:'10:00', end:'12:00' }
];

const Row = ({ id, title, priority, type, complete, incomplete, begin, end, toRemove, remove }) => (
    <div className="row">
        <div className="remove">
            {toRemove ?
                <a href="#" onClick={() => remove(id)} style={{ color: '#85D8CE', fontSize: '20px' }}>
                    <FontAwesomeIcon icon={faTrash} />
                </a>
                :
                <a href="#" style={{ color: '#85D8CE', fontSize: '20px' }}>
                    <FontAwesomeIcon icon={faPlusCircle} />
                </a>
            }
        </div>
        <div style={{ fontSize: '20px' }}>{id}</div>
        <div style={{ fontSize: '20px' }}>{title}</div>
        <div style={{ fontSize: '20px' }}>{priority}</div>
        <div style={{ fontSize: '20px' }}>{type}</div>
        <div style={{ fontSize: '20px' }}>{complete}</div>
        <div style={{ fontSize: '20px' }}>{incomplete}</div>
        <div style={{ fontSize: '20px' }}>{begin}</div>
        <div style={{ fontSize: '20px' }}>{end}</div>
    </div>
);

class Table extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: []
        }
    }

    componentDidMount() {
        this.setState({ data: this.props.data });
    }

    compareBy = (key) => {
        return function (a, b) {
            if (a[key] < b[key]) return -1;
            if (a[key] > b[key]) return 1;
            return 0;
        };
    };

    sortBy = (key) => {
        let arrayCopy = [...this.state.data];
        arrayCopy.sort(this.compareBy(key));
        this.setState({ data: arrayCopy });
    };

    remove = (rowId) => {
        const arrayCopy = this.state.data.filter((row) => row.id !== rowId);
        this.setState({ data: arrayCopy });
    };

    render() {
        return (
            <div className="table">
                <div className="header">
                    <div className="remove" style={{ fontSize: '35px' }}></div>
                    <div onClick={() => this.sortBy('id')} style={{ color: 'white', fontSize: '20px' }}>Place</div>
                    <div onClick={() => this.sortBy('title')} style={{ color: 'white', fontSize: '20px' }}>Location</div>
                    <div onClick={() => this.sortBy('priority')} style={{ color: 'white', fontSize: '20px' }}>Area (m²)</div>
                    <div onClick={() => this.sortBy('type')} style={{ color: 'white', fontSize: '20px' }}>Capacity</div>
                    <div onClick={() => this.sortBy('complete')} style={{ color: 'white', fontSize: '20px' }}>Price</div>
                    <div onClick={() => this.sortBy('incomplete')} style={{ color: 'white', fontSize: '20px' }}>Weather</div>
                    <div onClick={() => this.sortBy('begin')} style={{ color: 'white', fontSize: '20px' }}>Begin</div>
                    <div onClick={() => this.sortBy('end')} style={{ color: 'white', fontSize: '20px' }}>End</div>
                </div>
                <div className="body">
                    {this.state.data.map((rowData) => <Row toRemove={this.props.toRemove} remove={this.remove} {...rowData} />)}
                </div>
            </div>
        );
    }
};

const Places = () => (
    <Layout>
        <h2 style={{ margin: '35px 0px 0px 75px', color: '#85D8CE' }}>Next appointments</h2>
        <Table data={values1} toRemove={true} />
        <h2 style={{ margin: '35px 0px 0px 75px', color: '#85D8CE' }}>Available places</h2>
        <Table data={values1} toRemove={false} />
    </Layout>
);

export default Places;