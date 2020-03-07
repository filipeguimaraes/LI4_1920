import React from 'react';
import '../styles/user.css';
import { Grid, Cell } from 'react-mdl';

import userLogo from '../images/marcelo.jpg';

import placeIcon from '../images/menu-1.png';
import classIcon from '../images/menu-2.png';
import statistcsIcon from '../images/menu-3.png';
import settingsIcon from '../images/menu-4.png';

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
                        <div class="flag note">
                            <div class="flag__image note__icon">
                                <i class="fa fa-heart"></i>
                            </div>
                            <div class="flag__body note__text">
                                Default color
    </div>
                            <a href="#" class="note__close">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                        <div class="flag note note--secondary">
                            <div class="flag__image note__icon">
                                <i class="fa fa-comment"></i>
                            </div>
                            <div class="flag__body note__text">
                                Secondary color
    </div>
                            <a href="#" class="note__close">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>

                        <div class="flag note note--success">
                            <div class="flag__image note__icon">
                                <i class="fa fa-check"></i>
                            </div>
                            <div class="flag__body note__text">
                                Your thing was successful!
    </div>
                            <a href="#" class="note__close">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>

                        <div class="flag note note--warning">
                            <div class="flag__image note__icon">
                                <i class="fa fa-exclamation"></i>
                            </div>
                            <div class="flag__body note__text">
                                Your thing was not so successful!
    </div>
                            <a href="#" class="note__close">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>

                        <div class="flag note note--error">
                            <div class="flag__image note__icon">
                                <i class="fa fa-times"></i>
                            </div>
                            <div class="flag__body note__text">
                                Your thing failed completely!
    </div>
                            <a href="#" class="note__close">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>

                        <div class="flag note note--info">
                            <div class="flag__image note__icon">
                                <i class="fa fa-info"></i>
                            </div>
                            <div class="flag__body note__text">
                                <p>I barely knew Philip, but as a clergyman I have no problem telling his most intimate friends all about him. Calculon is gonna kill us and it's all everybody else's fault! Is that a cooking show? When will that be? Shut up and get to the point! Bender, being God isn't easy. If you do too much, people get dependent on you, and if you do nothing, they lose hope. You have to use a light touch. Like a safecracker, or a pickpocket.</p>
                            </div>
                            <a href="#" class="note__close">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>

                    </div>
                </Cell>
            </Grid>
        </div>
    </Layout>
);

export default User;
