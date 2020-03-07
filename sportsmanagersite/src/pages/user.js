import React from 'react';
import '../styles/user.css';
import { Grid, Cell } from 'react-mdl';

import userLogo from '../images/marcelo.jpg';

import placeIcon from '../images/menu-1.png';
import classIcon from '../images/menu-2.png';
import statistcsIcon from '../images/menu-3.png';
import settingsIcon from '../images/menu-4.png';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faBasketballBall, faBiking} from '@fortawesome/free-solid-svg-icons'

import Layout from '../layouts/UserLayout';

const menus = [
    {
        "link": "#1",
        "img": placeIcon,
        "name": "Cena 1",
        "number": "1"
    },
    {
        "link": "#2",
        "img": classIcon,
        "name": "Cena 2",
        "number": "2"
    },
    {
        "link": "#3",
        "img": statistcsIcon,
        "name": "Cena 3",
        "number": "3"
    },
    {
        "link": "#4",
        "img": settingsIcon,
        "name": "Cena 4",
        "number": "4"
    }
]

const notes = [
    {
        "flag": "flag note",
        "img": "flag__image note__icon",
        "icon": faBasketballBall,
        "text": "flag__body note__text",
        "notification": "Book basketball court",
        "ref": "note__close",
        "cross": "fa fa-times"
    },
    {
        "flag": "flag note note--secondary",
        "img": "flag__image note__icon",
        "icon": faBiking,
        "text": "flag__body note__text",
        "notification": "Attend cycling class",
        "ref": "note__close",
        "cross": "fa fa-times"
    }
]

const User = () => (
    <Layout>
        <div style={{ width: '100%', margin: 'auto' }}>
            <Grid className="user-grid">
                <Cell col={12}>
                    <img
                        src={userLogo}
                        alt="sports"
                        id="profile-img"
                    />
                    <div>
                        <h1 style={{ color: '#85D8CE', textAlign: "center" }}>Welcome, John!</h1>
                    </div>
                </Cell>
                <Cell col={12}>
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
                </Cell>
                <Cell style={{ margin: '80px' }} col={12}>
                    <div class="sugestions-container">
                        <h1 style={{ color: '#85D8CE', textAlign: "left" }}>Based on your last purchases</h1>
                        {notes.map(note => (
                            <div class={note.flag}>
                                <div class={note.img}>
                                <FontAwesomeIcon icon={note.icon} />
                                </div>
                                <div class={note.text}>
                                    {note.notification}
                                </div>
                                <a href="#" class={note.ref}>
                                    <i class={note.cross}></i>
                                </a>
                            </div>
                        ))}
                    </div>
                </Cell>
            </Grid>
        </div>
    </Layout>
);

export default User;
