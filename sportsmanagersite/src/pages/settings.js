import React, { Component } from 'react';

import Layout from '../layouts/UserLayout';

import { Cell, Grid } from 'react-mdl';
import profileLogo from '../images/male_avatar-512.png';
import '../styles/register.css';

import { checkAuthentication, checkSettings, validateAuth, varsSettings } from '../components/WebAPI';
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
            email: React.createRef(),
            password: React.createRef(),
            username: React.createRef(),
            gender: 'I',
            address: React.createRef(),
            contact: React.createRef(),
            day: React.createRef(),
            month: React.createRef(),
            year: React.createRef(),
            height: React.createRef(),
            weight: React.createRef(),
            alreadyLogged: 'loading'
        }

        this.handleSave = this.handleSave.bind(this);

        this.handleFemale = this.handleFemale.bind(this);
        this.handleMale = this.handleMale.bind(this);
    }

    async componentWillMount() {
        await checkSettings(this);
        await checkAuthentication(this);
    }

    handleFemale() {
        this.setState({gender: 'F'});
    }

    handleMale() {
        this.setState({gender: 'M'});
    }

    handleSave() {
        varsSettings(
            this.state.email.current.value,
            this.state.password.current.value,
            this.state.username.current.value,
            this.state.gender,
            this.state.address.current.value,
            this.state.contact.current.value,
            this.state.day.current.value,
            this.state.month.current.value,
            this.state.year.current.value,
            this.state.height.current.value,
            this.state.weight.current.value
        );
    }

    render() {
        if (this.state.alreadyLogged !== validUser && this.state.alreadyLogged !== 'settings') return validateAuth(this, validUser);

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
                            <form class="form-wrap">
                                <div>
                                    <label for="email">Email</label>
                                    <input type="text" ref={this.state.email} />
                                </div>
                                <div>
                                    <label for="password">Password</label>
                                    <input type="password" ref={this.state.password} />
                                </div>
                                <div>
                                    <label for="name">Name</label>
                                    <input type="text" ref={this.state.username} />
                                </div>

                                <div className="radio">
                                    <span>Gender</span>
                                    <Grid>
                                        <Cell col={6}>
                                            <label>
                                                <input type="radio" value="F" onClick={this.handleFemale} />Female
                                                <div className="radio-control female" />
                                            </label>
                                        </Cell>
                                        <Cell col={6}>
                                            <label>
                                                <input type="radio" value="M" onClick={this.handleMale} />Male
                                                <div className="radio-control male"></div>
                                            </label>
                                        </Cell>
                                    </Grid>
                                </div>
                                <div>
                                    <label for="address">Address</label>
                                    <input type="text" ref={this.state.address} />
                                </div>
                                <div>
                                    <label for="contact">Phone number</label>
                                    <input type="text" ref={this.state.contact} />
                                </div>
                                <span>Date of birth</span>
                                <Grid >
                                    <Cell col={4}>
                                        <div>
                                            <select type="text" ref={this.state.day}>
                                                <option>Day</option>
                                                {dias.map(dia => (
                                                    <option value={dia}>{dia}</option>
                                                ))}
                                            </select>
                                        </div>
                                    </Cell>
                                    <Cell col={4}>
                                        <div>
                                            <select type="text" ref={this.state.month}>
                                                <option>Month</option>
                                                {meses.map(mes => (
                                                    <option value={mes}>{mes}</option>
                                                ))}

                                            </select>
                                        </div>
                                    </Cell>
                                    <Cell col={4}>
                                        <div>
                                            <select type="text" ref={this.state.year}>
                                                <option>Year</option>
                                                {anos.map(ano => (
                                                    <option value={ano}>{ano}</option>
                                                ))}
                                            </select>
                                        </div>
                                    </Cell>
                                </Grid>
                                <div>
                                    <label for="height">Height</label>
                                    <input type="text" ref={this.state.height} />
                                </div>
                                <div>
                                    <label for="weight">Weight</label>
                                    <input type="text" ref={this.state.weight} />
                                </div>
                                <button onClick={this.handleSave}>save</button>
                            </form>
                        </Cell>
                    </Grid>
                </div>
            </Layout>
        );
    }
}

export default Settings;