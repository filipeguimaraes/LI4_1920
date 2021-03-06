import React, { Component } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faTrash, faPlusCircle } from '@fortawesome/free-solid-svg-icons'


const Row = ({ id, title, priority, type, complete, incomplete, toRemove, remove }) => (
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
    </div>
);

class TableClasses extends Component {
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

export default TableClasses;