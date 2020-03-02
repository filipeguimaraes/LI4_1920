import React from 'react';
import '../styles/contact.css';
import { Grid, Cell, List, ListItem, ListItemContent } from 'react-mdl';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPhone, faEnvelope } from '@fortawesome/free-solid-svg-icons'

const Contact = () => (
    <div className="contact-body">
        <Grid className="contact-grid">
        <Cell col={6}>
            
            {/* <hr /> */}
            <div className="contact-list">
            <h2>Contact Us</h2>
                <List>
                    <ListItem>
                        <ListItemContent style={{ fontSize: '30px', color: '#85D8CE' }}>
                            <FontAwesomeIcon icon={faPhone} />
                            &nbsp;
                                123 456 789
                            </ListItemContent>
                    </ListItem>

                    <ListItem>
                        <ListItemContent style={{ fontSize: '30px', color: '#85D8CE' }}>
                            <FontAwesomeIcon icon={faEnvelope} />
                            &nbsp;
                                someone@example.com
</ListItemContent>
                    </ListItem>

                </List>
            </div>
        </Cell>
        
            <Cell col={6}>
                <form className="login-form">
                    <input type="text" placeholder="email" />
                    <input type="text" placeholder="subject" />
                    <textarea placeholder="message" required />
                    <button>submit</button>
                </form>
            </Cell>

        </Grid>
    </div>
);

export default Contact;

/*       <div className="contact-body">
                                                <Grid className="contact-grid">
                                                    <Cell col={6}>
                                                        <h2>Human Resources</h2>
                                                        <img
                                                            src="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSWJFlDd0blYrHSJgCaZlhEpI3iMngIvi87qW8dSjha6rGu_SFz"
                                                            alt="avatar"
                                                            style={{ height: '250px' }}
                                                        />
                                                        <p style={{ width: '75%', margin: 'auto', paddingTop: '1em' }}>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.</p>
                                                    </Cell>
                                                    <Cell col={6}>
                                                        <h2>Contact Us</h2>
                                                        <hr />

                                                        <div className="contact-list">
                                                            <List>
                                                                <ListItem>
                                                                    <ListItemContent style={{ fontSize: '30px', fontFamily: 'Anton', color: '#85D8CE' }}>
                                                                        <FontAwesomeIcon icon={faPhone} />
                                                                        &nbsp;
                                                                            123 456 789
                            </ListItemContent>
                                                                </ListItem>

                                                                <ListItem>
                                                                    <ListItemContent style={{ fontSize: '30px', fontFamily: 'Anton', color: '#85D8CE' }}>
                                                                        <FontAwesomeIcon icon={faEnvelope} />
                                                                        &nbsp;
                                                                            someone@example.com
                            </ListItemContent>
                                                                </ListItem>

                                                            </List>
                                                        </div>
                                                    </Cell>
                                                </Grid>
                                            </div>
                                            */