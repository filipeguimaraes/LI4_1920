import React, { Component } from 'react';

import Layout from '../layouts/UserLayout';

import { Cell, Grid } from 'react-mdl';
import profileLogo from '../images/male_avatar-512.png';
import '../styles/register.css';

import { checkAuthentication, validateAuth } from '../components/WebAPI';
import { validUser } from './user';


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

const dias = Array.from({ length: 31 }, (v, i) => i + 1);

const anos = Array.from({ length: 51 }, (v, i) => i + 1970);

class Settings extends Component {
    constructor(props) {
        super(props);
        this.state = {
            data: [],
            alreadyLogged: 'loading'
        }
    }

    async componentWillMount() {
        await checkAuthentication(this);
    }

    render() {
        if (this.state.alreadyLogged !== validUser) return validateAuth(this, validUser);

        return (
            <Layout>
                <div className="form-wrap">
                    <Grid >
                        <Cell col={6} className="profile">
                            <div class="avatar" id="avatar">
                                <div id="preview"><img src={profileLogo} alt="register" id="avatar-image" class="avatar_img" />
                                </div>
                                <div class="avatar_upload">
                                    <label class="upload_label">Upload
                            <input type="file" id="upload" />
                                    </label>
                                </div>
                            </div>
                            <div class="nickname">
                                <span id="name" tabindex="4" data-key="1" contenteditable="true" onkeyup="changeAvatarName(event, this.dataset.key, this.textContent)" onblur="changeAvatarName('blur', this.dataset.key, this.textContent)"></span>
                            </div>
                        </Cell>
                        <Cell col={6} style={{ maxWidth: '400px', margin: '0 auto' }}>
                            <form method="post" action="form.php">
                                <div>
                                    <label for="email">Email</label>
                                    <input type="text" name="name" />
                                </div>
                                <div>
                                    <label for="name">Password</label>
                                    <input type="password" name="name" />
                                </div>
                                <div>
                                    <label for="name">Name</label>
                                    <input type="text" name="name" />
                                </div>

                                <div className="radio">
                                    <span>Gender</span>
                                    <Grid>
                                        <Cell col={6}>
                                            <label>
                                                <input type="radio" name="sex" value="female" />Female
                                        <div className="radio-control female" />
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
                                    <input name="email" />
                                </div>
                                <div>
                                    <label for="email">Phone number</label>
                                    <input name="email" />
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
                                    <label for="email">Height</label>
                                    <input name="email" />
                                </div>
                                <div>
                                    <label for="email">Weight</label>
                                    <input name="email" />
                                </div>
                                <button type="submit">save</button>
                            </form>
                        </Cell>
                    </Grid>
                </div>
            </Layout>
        );
    }
}

export default Settings;