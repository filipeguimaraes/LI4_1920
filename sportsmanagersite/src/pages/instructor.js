import React from 'react';
import { DataTable, TableHeader, Grid, Cell, Tooltip, Icon } from 'react-mdl';
import '../styles/instructor.css';

import Layout from '../layouts/AuthenticatedLayout';

const Instructor = () => (
    <Layout>
    <div >
        <Grid className="table">
            <Cell col={6} style={{ margin: 'auto' }}>
                <DataTable align='right'
                    shadow={0}
                    rows={[
                        { class: 'Aerobics', quantity: 'Gym', price: 2.90, capacity: '20', begin: '12:00', end: '13:00'},
                        { class: 'Cycling', quantity: 'Gym', price: 1.25, capacity: '15', begin: '16:00', end: '17:00'},
                        { class: 'Tennis', quantity: 'Tennis court', price: 2.35, capacity: '6', begin: '18:00', end: '20:00' }
                    ]}
                >
                    <TableHeader name="class" >Class</TableHeader>
                    <TableHeader name="quantity" >Place</TableHeader>
                    <TableHeader name="price" cellFormatter={(price) => `$${price.toFixed(2)}`} >Price</TableHeader>
                    <TableHeader name="capacity" >Capacity</TableHeader>
                    <TableHeader name="begin" >Begin</TableHeader>
                    <TableHeader name="end" >End</TableHeader>
                </DataTable>

            </Cell>
            <Cell col={6} style={{ margin: 'auto' }}>
                <Tooltip label="New class">
                    <Icon name="add" align='left'/>
                </Tooltip>
            </Cell>

        </Grid>
    </div>
    </Layout>
);

export default Instructor;
