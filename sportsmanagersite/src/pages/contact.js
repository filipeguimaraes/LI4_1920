import React from 'react';
import '../styles/contact.css';
import { Grid, Cell, List, ListItem, ListItemContent } from 'react-mdl';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faPhone, faEnvelope } from '@fortawesome/free-solid-svg-icons'

const Contact = () => (
    <div className="contact-body">
        <Grid className="contact-grid">
            <Cell col={6}>
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
                    <input type="text" placeholder="email" required />
                    <input type="text" placeholder="subject" />
                    <textarea placeholder="message" />
                    <button>submit</button>
                </form>
            </Cell>
        </Grid>
    </div>
);

export default Contact;
