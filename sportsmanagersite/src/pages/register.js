import React from 'react';
import { Cell, Grid } from 'react-mdl';
import profileLogo from '../images/male_avatar-512.png';
import '../styles/register.css';

import Layout from '../layouts/BaseLayout';

const meses = [
    "Janeiro",
    "Fevereiro",
    "Março",
    "Abril",
    "Maio",
    "Junho",
    "Julho",
    "Agosto",
    "Setembro",
    "Outubro",
    "Novembro",
    "Dezembro"
]


const links = [
    {
        link: "/",
        text: "Home"
    }
]

const dias = Array.from({ length: 31 }, (v, i) => i + 1);

const anos = Array.from({ length: 51 }, (v, i) => i + 1970);

const Register = () => (
    <Layout pages={links}>
        <div className="form-wrap">
            <Grid >
                <Cell col={6} className="profile">
                    <img 
                    alt="profile" 
                    src={profileLogo}
                    id="profile-img" 
                    />
                </Cell>
                <Cell col={6}>
                    <form method="post" action="form.php">
                        <div>
                            <label for="name">Name</label>
                            <input type="text" name="name" required />
                        </div>

                        <div className="radio">
                            <span>Gender</span>
                            <Grid>
                                <Cell col={6}>
                                    <label>
                                        <input type="radio" name="sex" value="female" />Female
        <div className="radio-control female"></div>

                                    </label>
                                </Cell>
                                <Cell col={6}>
                                    <label>
                                        <input type="radio" name="sex" value="male" />Male
        <div className="radio-control male"></div>
                                    </label>
                                </Cell>
                            </Grid>
                        </div>
                        <div>
                            <label for="email">Address</label>
                            <input type="email" name="email" required />
                        </div>
                        <div>
                            <label for="email">Phone number</label>
                            <input type="email" name="email" required />
                        </div>
                        <span>Date of birth</span>
                        <Grid >
                            <Cell col={4}>

                                <div>

                                    <select name="day">
                                        <option>Day</option>
                                        {dias.map(dia => (
                                            <option value={dia}>{dia}</option>
                                        ))}
                                    </select>
                                </div>
                            </Cell>
                            <Cell col={4}>
                                <div>
                                    <select name="month">
                                        <option>Month</option>
                                        {meses.map(mes => (
                                            <option value={mes}>{mes}</option>
                                        ))}

                                    </select>
                                </div>
                            </Cell>
                            <Cell col={4}>
                                <div>
                                    <select name="year">
                                        <option>Year</option>
                                        {anos.map(ano => (
                                            <option value={ano}>{ano}</option>
                                        ))}
                                    </select>
                                </div>
                            </Cell>
                        </Grid>
                        <div>
                            <label for="email">Tax ID number</label>
                            <input type="email" name="email" required />
                        </div>
                        <div>
                            <label for="email">Height</label>
                            <input type="email" name="email" required />
                        </div>
                        <div>
                            <label for="email">Weight</label>
                            <input type="email" name="email" required />
                        </div>
                        <button type="submit">submit</button>
                    </form>
                </Cell>
            </Grid>
        </div>
    </Layout>
);

export default Register;
