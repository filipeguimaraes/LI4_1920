import React from 'react';
import { Redirect } from 'react-router-dom';

import uuid from 'uuid';
import Axios from 'axios';

import loadingPage from '../pages/loading';
import errorPage from '../pages/error';


// EXPORTABLE CONSTANTS

export const baseURL = 'https://localhost:44384/'

export const proxyURL = 'https://cors-anywhere.herokuapp.com/'

export const baseConfig = {
    headers:{
        'Access-Control-Allow-Origin': '*',
        'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE',
        'Access-Control-Allow-Headers': 'Origin, Content-Type, X-Auth-Token',
        'Content-Type': 'application/json',
        'Access-Control-Expose-Headers': 'Access-Token, Uid',
        'proxy': 'localhost:3000'
    }
};



// LOGIN and LOGOUT and AUTHENTICATION

// Constants
const sessionKEY = 'ssKeyId';
const sessionID = 'ssValueUid';
const inEMAIL = 'loginEmail';
const inPASSWORD = 'loginPassword';
const errorAPI = 'error';

// Remove the keys of the sessions a sends the API logout request
export function logout () {
    /**
     * LOGOUT REQUEST API
     */
    localStorage.removeItem(sessionID);
    localStorage.removeItem(sessionKEY);
}

// Sets the inputs in sessionStorage for logging in.
export function varsLogin (email, password) {
    sessionStorage.setItem(inEMAIL,email);
    sessionStorage.setItem(inPASSWORD,password);
}

/** Gets the unique ids for authentication session. 
 * 
 * @param obj: acess this.state.alreadyLogged 
 */
export async function checkLogin (obj) {
    var lEmail = sessionStorage.getItem(inEMAIL);
    var lPass = sessionStorage.getItem(inPASSWORD);

    if (lEmail !== null && lPass !== null) {

        obj.setState({ alreadyLogged: 'loading'});
        sessionStorage.removeItem(inEMAIL);
        sessionStorage.removeItem(inPASSWORD);

        await Axios.get(baseURL+`Login?email=${lEmail}&password=${lPass}`,baseConfig)
            .then(r => {
                if (r.data === 'user' || r.data === 'instructor') {
                    localStorage.setItem(sessionID,r.data);
                    localStorage.setItem(sessionKEY,r.data);
                }
                else {
                    obj.setState({ alreadyLogged: null});
                }
            })
            .catch(() => {
                obj.setState({ alreadyLogged: errorAPI});
            });
    }
}


/** Changes the obj.state.alreadyLogged to the name a permission:
 * 'user', 'instructor', 'loading', 'error' or null.
 * 
 * @param obj: acess this.state.alreadyLogged 
 */
export async function checkAuthentication (obj) {
    var vUid = localStorage.getItem(sessionID);
    var kUid = localStorage.getItem(sessionKEY);

    if (vUid !== null && kUid !== null) {

        await Axios.get(baseURL+`Authentication?${sessionKEY}=${kUid}&${sessionID}=${vUid}`,baseConfig)
            .then(r => {
                if (r.data === 'user' || r.data === 'instructor') {
                    obj.setState({ alreadyLogged: r.data});
                }
                else {
                    obj.setState({ alreadyLogged: null});
                }
            })
            .catch(() => {
                obj.setState({ alreadyLogged: errorAPI});
            });
    }
}

//
export function validateAuth (obj, val) {
    if(obj.state.alreadyLogged === null) return (<Redirect to={{ pathname: '/login' }}/>);
    if(obj.state.alreadyLogged === 'loading') return loadingPage();
    if(obj.state.alreadyLogged === 'error') return errorPage();
    if(obj.state.alreadyLogged !== val) return (<Redirect to={{ pathname: '/'+obj.state.alreadyLogged }}/>);
}

/** MY SANDBOX OF JS
 *
 *  await axios.get(baseURL+'Instructor?log=true',baseConfig)
            .then(result => {
                this.setState({loading: false, logged: result.data.log});
                if(!localStorage.getItem('instructor object')){
                    localStorage.setItem('instructor object',JSON.stringify(result.data));
                    console.log(JSON.parse(localStorage.getItem('instructor object')));
                }
                if (!sessionStorage.getItem('time')){
                    sessionStorage.setItem('time',new Date().toJSON());
                }
            })
            .catch(e => { this.setState({ loading: true, logged: true }); });
 */