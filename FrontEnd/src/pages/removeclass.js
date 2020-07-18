import React, { Component } from 'react';
import { DataTable, TableHeader, Grid, Cell } from 'react-mdl';
import Layout from '../layouts/InstructorLayout';
import "../styles/removeclass.css";

import { makeStyles } from '@material-ui/core/styles';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper } from '@material-ui/core';


const classes = makeStyles({
    table: {
        minWidth: 650,
    },
});

function createData(type, place, price, capacity, begin, end) {
    return { type, place, price, capacity, begin, end };
}

const rows = [
    createData( 'Aerobics', 'Gym', 2.90, '20', '12:00', '13:00' ),
    createData( 'Cycling', 'Gym', 1.25, '15', '16:00', '17:00' ),
    createData( 'Tennis', 'Tennis court', 2.35, '6', '18:00', '20:00' )
];

class RemoveClass extends Component {

    render() {
        return (
            <Layout>
                <div style={{ width: '80%', margin: 'auto' }}>
                    <h1>Remove Class</h1>
                    <form method="post" action="form.php">
                        <Grid >
                            <Cell col={12} style={{ margin: '0 auto' }}>
                                <TableContainer component={Paper}>
                                    <Table className={classes.table} aria-label="simple table">
                                        <TableHead>
                                            <TableRow>
                                                <TableCell>Class</TableCell>
                                                <TableCell align="left">Place</TableCell>
                                                <TableCell align="left">Price</TableCell>
                                                <TableCell align="left">Capacity</TableCell>
                                                <TableCell align="left">Begin</TableCell>
                                                <TableCell align="left">End</TableCell>
                                            </TableRow>
                                        </TableHead>
                                        <TableBody>
                                            {rows.map(row => (
                                                <TableRow key={row.type}>
                                                    <TableCell component="th" scope="row">
                                                        {row.type}
                                                    </TableCell>
                                                    <TableCell align="left">{row.place}</TableCell>
                                                    <TableCell align="left">{`$${row.price.toFixed(2)}`}</TableCell>
                                                    <TableCell align="left">{row.capacity}</TableCell>
                                                    <TableCell align="left">{row.begin}</TableCell>
                                                    <TableCell align="left">{row.end}</TableCell>
                                                </TableRow>
                                            ))}
                                        </TableBody>
                                    </Table>
                                </TableContainer>
                                <h3></h3>
                                <Cell col={4} style={{ margin: '0 auto' }}>
                                    <button type="remove">Remove Selected</button>
                                </Cell>
                            </Cell>
                        </Grid>
                    </form>
                </div>
            </Layout>
        );
    }
}

export default RemoveClass;