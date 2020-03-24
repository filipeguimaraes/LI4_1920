import React, { Component } from 'react';
import Layout from '../layouts/InstructorLayout';
import "../styles/removeclass.css";
import MaterialTable from "material-table";


class CancelClass extends Component {


    render() {
        return (
            <Layout>
                <div style={{ width: '80%', margin: 'auto' }}>
                    <h1>Cancel Classes</h1>
                    <MaterialTable
                        title="Casses"
                        columns={[
                            { title: "Modality", field: "class" },
                            { title: "Place", field: "place" },
                            { title: "Price", field: "price", type: "money" },
                            { title: "Capacity", field: "capacity" },
                            { title: "Begin", field: "begin" },
                            { title: "End", field: "end" }
                        ]}

                        data={[
                            { class: 'Aerobics', place: 'Gym', price: 2.90, capacity: '20', begin: '12:00', end: '13:00' },
                            { class: 'Cycling', place: 'Gym', price: 1.25, capacity: '15', begin: '16:00', end: '17:00' },
                            { class: 'Tennis', place: 'Tennis court', price: 2.35, capacity: '6', begin: '18:00', end: '20:00' }
                        ]}

                        actions={[
                            {
                                icon: 'delete',
                                onClick: (event, rowData) => {
                                    // Do save operation
                                }
                            }
                        ]}

                    />
                </div>
            </Layout>
        );
    }
}

export default CancelClass;