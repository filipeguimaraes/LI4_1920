import React, { Component } from 'react';
import { Grid, Cell } from 'react-mdl';
import '../styles/instructor.css';

import userLogo from '../images/marcelo.jpg';

import Layout from '../layouts/InstructorLayout';
import Chart from '../components/Chart.js';

import { checkAuthentication, validateAuth } from '../components/WebAPI';


export const validInstructor = 'instructor';

let classesData = [
    {
        id: 1,
        name: "Aerobics",
        place: "Gym",
        price: "2.90",
        capacity: "20",
        begin: "12:00",
        end: "13:00",
        editable: false
    },
    {
        id: 2,
        name: "Cycling",
        place: "Gym",
        price: "1.25",
        capacity: "15",
        begin: "16:00",
        end: "17:00",
        editable: false
    }
];

class Instructor extends Component {
    constructor() {
        super();

        this.state = {
            chartData: {},
            classes: [],
            alreadyLogged: 'loading'
        }
    }

    async componentWillMount() {
        this.getChartData();
        this.getClassesData();
        await checkAuthentication(this);
    }

    getClassesData() {
        this.setState({
            classes: classesData
        })
    }

    changeClass(event){
        console.log(event);
    }

    saveEditable = (classId) => {
        const newArray = this.state.classes.map((row) => (
            row.id === classId ?  {...row,editable:false}
                        :
            row 
        ));
        this.setState({ classes: newArray });
    }

    makeEditable = (classId) => {
        const newArray = this.state.classes.map((row) => (
            row.id === classId ?  {...row,editable:true}
                        :
            row 
        ));
        this.setState({ classes: newArray });
    }

    removeClass = (classId) => {
        const arrayCopy = this.state.classes.filter((row) => row.id !== classId);
        this.setState({ classes: arrayCopy });
    };

    getChartData() {
        // Ajax calls here
        this.setState({
            chartData: {
                labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                datasets: [
                    {
                        label: 'Income',
                        data: [
                            700,
                            800,
                            933,
                            965,
                            543,
                            456,
                            768,
                            954,
                            453,
                            964,
                            865,
                            458
                        ],
                        backgroundColor: '#96DEDA'
                    }
                ]
            }
        });
    }

    render() {
        if(this.state.alreadyLogged !== validInstructor) return validateAuth(this, validInstructor);

        return (
            <Layout>
                <div style={{ width: '80%', margin: 'auto' }}>
                    <Grid className="profile-instructor">
                        <Cell col={4} style={{ align: 'center', margin: 'auto' }}>
                            <div>
                                <img
                                    src={userLogo}
                                    alt="Imagem"
                                    className="profile-instructor-img"
                                />
                                <h3 style={{ color: '#85D8CE', textAlign: "center" }}>Welcome,  John!</h3>
                            </div>
                        </Cell>
                        <Cell col={8} style={{ margin: 'auto' }}>
                            <Chart chartData={this.state.chartData} />
                        </Cell>
                        <Cell col={12}>
                            <table className="table-instructor">
                                <thead>
                                    <tr>
                                        <th>Class</th>
                                        <th>Place</th>
                                        <th>Price</th>
                                        <th>Capacity</th>
                                        <th>Begin</th>
                                        <th>End</th>
                                        <th>Actions <button className="add">New</button></th>
                                    </tr>
                                </thead>
                                <tbody>
                                    {this.state.classes.map(c => (
                                        (
                                            c.editable ? (
                                                <tr key={c.id}>
                                                    <td className="data">
                                                        <input type="text" name="name" placeholder={c.name} />
                                                    </td>
                                                    <td className="data">
                                                        <input type="text" name="place" placeholder={c.place}/>
                                                    </td>
                                                    <td className="data">
                                                        <input type="text" name="price" placeholder={c.price}/>
                                                    </td>
                                                    <td className="data">
                                                        <input type="text" name="capacity" placeholder={c.capacity}/>
                                                    </td>
                                                    <td className="data">
                                                        <input type="text" name="begin" placeholder={c.begin}/>
                                                    </td>
                                                    <td className="data">
                                                        <input type="text" name="end" placeholder={c.end}/>
                                                    </td>
                                                    <td>
                                                        <input type="submit" value="Save" className="save" onClick={() => this.saveEditable(c.id)}/>
                                                    </td>
                                                </tr>
                                            )
                                                :
                                                (
                                                    <tr key={c.id}>
                                                        <td className="data">{c.name}</td>
                                                        <td className="data">{c.place}</td>
                                                        <td className="data">{c.price}</td>
                                                        <td className="data">{c.capacity}</td>
                                                        <td className="data">{c.begin}</td>
                                                        <td className="data">{c.end}</td>
                                                        <td>
                                                            <button onClick={() => this.makeEditable(c.id)} className="edit">Edit</button>
                                                            <button onClick={() => this.removeClass(c.id)} className="delete">Cancel</button>
                                                        </td>
                                                    </tr>
                                                )
                                        )
                                    ))}
                                </tbody>
                            </table>
                        </Cell>
                    </Grid>
                </div>
            </Layout>
        );
    }
}

export default Instructor;