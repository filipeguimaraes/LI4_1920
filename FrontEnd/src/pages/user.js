import React, { Component } from 'react';
import '../styles/user.css';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';

import userLogo from '../images/marcelo.jpg';

import placeIcon from '../images/menu-1.png';
import classIcon from '../images/menu-2.png';
import statistcsIcon from '../images/menu-3.png';
import settingsIcon from '../images/menu-4.png';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBasketballBall, faBiking } from '@fortawesome/free-solid-svg-icons'

import Layout from '../layouts/UserLayout';
import MyCard from '../components/MyCard';

import { checkAuthentication, validateAuth } from '../components/WebAPI';


export const validUser = 'user';

const menus = [
    {
        "link": "/places",
        "img": placeIcon,
        "name": "Cena 1",
        "number": "1"
    },
    {
        "link": "/classes",
        "img": classIcon,
        "name": "Cena 2",
        "number": "2"
    },
    {
        "link": "/statistics",
        "img": statistcsIcon,
        "name": "Cena 3",
        "number": "3"
    },
    {
        "link": "/settings",
        "img": settingsIcon,
        "name": "Cena 4",
        "number": "4"
    }
]

const notifications = [
    {
        "id": 1,
        "flag": "flag note",
        "icon": faBasketballBall,
        "message": "Book basketball court"
    },
    {
        "id": 2,
        "flag": "flag note note--secondary",
        "icon": faBiking,
        "message": "Attend cycling class"
    }
]

class User extends Component {
    constructor(props) {
        super(props);

        this.state = {
            notifications,
            name: 'N/A',
            alreadyLogged: 'loading',
            creditos: 0
        }
    }

    async componentWillMount() {
        await checkAuthentication(this);
    }

    removeNotification(id) {
        let newNotificatons = this.state.notifications;
        const index = newNotificatons.findIndex(a => a.id === id);

        newNotificatons.splice(index, 1);

        this.setState(newNotificatons);
    }

    render() {
        if (this.state.alreadyLogged !== validUser) return validateAuth(this, validUser);

        return (
            <Layout>
                <div style={{ width: '100%', margin: 'auto' }}>
                    <Grid
                        container
                        direction="row"
                        justify="center"
                        alignItems="center"
                    >
                        <Grid item xs={8}>
                            <div style={{ display: "table-cell", verticalAlign: "middle", textAlign: "center" }}>
                                <img
                                    src={userLogo}
                                    alt="sports"
                                    id="profile-img"
                                />

                                <h1 style={{ color: '#85D8CE', textAlign: "center", padding: '15px' }}>
                                    Welcome, {this.state.name}!
                                </h1>
                            </div>
                        </Grid>
                        <Grid item xs>
                            <div style={{ padding: '30px' }}>
                                <MyCard money={this.state.creditos.toFixed(2)} />
                            </div>
                        </Grid>
                        <Grid item xs={12}>
                            <div id="icon-wrapper">
                                {menus.map(menu => (

                                    <a href={menu.link}>
                                        <div class={`icons${menu.number}`}>
                                            <div class="icon-slide-container">
                                                <img class="slide-icon" alt={menu.name} height="100" src={menu.img} />
                                            </div>
                                        </div>
                                    </a>

                                ))}

                            </div>
                        </Grid>
                        <Grid item style={{ margin: '80px' }} xs={12}>
                            <div class="sugestions-container">
                                <h1 style={{ color: '#85D8CE', textAlign: "left" }}>Based on your last purchases</h1>
                                {this.state.notifications.map(notification => (
                                    <div class={notification.flag}>
                                        <div class="flag__image note__icon">
                                            <FontAwesomeIcon icon={notification.icon} />
                                        </div>
                                        <div class="flag__body note__text">
                                            {notification.message}
                                        </div>
                                        <a onClick={() => this.removeNotification()} class="note__close">
                                            <i class="fa fa-times"></i>
                                        </a>
                                    </div>
                                ))}
                            </div>
                        </Grid>
                    </Grid>
                </div>
            </Layout>
        );
    }
}

export default User;
