import React, { Component } from 'react';
import Layout from '../layouts/UserLayout';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash, faPlus } from '@fortawesome/free-solid-svg-icons'

import '../styles/classes.css';

const values1 = [
    { id: 'Aerobics', title: 'Gym', priority: 2.90, type: '20', complete: '12:00', incomplete: '13:00' },
    { id: 'Cycling', title: 'Gym', priority: 1.25, type: '15', complete: '16:00', incomplete: '17:00' },
    { id: 'Tennis', title: 'Tennis court', priority: 2.35, type: '6', complete: '18:00', incomplete: '20:00' }
];




const Row = ({ id, title, priority, type, complete, incomplete, toRemove, remove }) => (
    <div className="row">
        <div className="remove">
            {toRemove ?
                <a href="#" onClick={() => remove(id)} style={{ color: '#85D8CE', fontSize: '20px' }}>
                    <FontAwesomeIcon icon={faTrash} />
                </a>
                :
                <a href="#" style={{ color: '#85D8CE', fontSize: '20px' }}>
                    <FontAwesomeIcon icon={faPlus} />
                </a>
            }
        </div>
        <div style={{ fontSize: '20px' }}>{id}</div>
        <div style={{ fontSize: '20px' }}>{title}</div>
        <div style={{ fontSize: '20px' }}>{priority}</div>
        <div style={{ fontSize: '20px' }}>{type}</div>
        <div style={{ fontSize: '20px' }}>{complete}</div>
        <div style={{ fontSize: '20px' }}>{incomplete}</div>
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

    /* 
       I like to write it this way to explicity state that a function is being returned
       But you could simplify this by using arrow syntax twice,
      
       compareBy = (key) => (a,b) => { ...... }
    */
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
        // Array.prototype.filter returns new array
        // so we aren't mutating state here
        const arrayCopy = this.state.data.filter((row) => row.id !== rowId);
        this.setState({ data: arrayCopy });
    };

    render() {
        return (
            <div className="table">
                <div className="header">
                    <div className="remove" style={{ fontSize: '35px' }}></div>
                    <div onClick={() => this.sortBy('id')} style={{ color: 'white', fontSize: '20px' }}>Class</div>
                    <div onClick={() => this.sortBy('title')} style={{ color: 'white', fontSize: '20px' }}>Place</div>
                    <div onClick={() => this.sortBy('priority')} style={{ color: 'white', fontSize: '20px' }}>Price</div>
                    <div onClick={() => this.sortBy('type')} style={{ color: 'white', fontSize: '20px' }}>Capacity</div>
                    <div onClick={() => this.sortBy('complete')} style={{ color: 'white', fontSize: '20px' }}>Begin</div>
                    <div onClick={() => this.sortBy('incomplete')} style={{ color: 'white', fontSize: '20px' }}>End</div>
                </div>
                <div className="body">
                    {this.state.data.map((rowData) => <Row toRemove={this.props.toRemove} remove={this.remove} {...rowData} />)}
                </div>
            </div>
        );
    }
};

const Classes = () => (
    <Layout>
        <h2 style={{ margin: '35px 0px 0px 75px', color: '#85D8CE' }}>Next classes</h2>
        <Table data={values1} toRemove={true} />
        <Table data={values1} toRemove={false} />
    </Layout>
);

export default Classes;