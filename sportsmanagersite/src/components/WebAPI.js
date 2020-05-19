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
    headers: {
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
const sessionKEY = 'ssKey';
const sessionID = 'ssValue';
const sessionTIME = 'ssTime';
const inEMAIL = 'loginEmail';
const inPASSWORD = 'loginPassword';
const errorAPI = 'error';

// Remove the keys of the sessions a sends the API logout request
export async function logout() {
    var kUid = localStorage.getItem(sessionKEY);
    var vUid = localStorage.getItem(sessionID);

    if (vUid !== null && kUid !== null) {

        await Axios.get(baseURL + `Logout?${sessionKEY}=${kUid}&${sessionID}=${vUid}`, baseConfig);
    }

    localStorage.removeItem(sessionID);
    localStorage.removeItem(sessionKEY);
}

// Sets the inputs in sessionStorage for logging in.
export function varsLogin(email, password) {
    sessionStorage.setItem(inEMAIL, email);
    sessionStorage.setItem(inPASSWORD, password);
}

/** Gets the unique ids for authentication session. 
 * 
 * @param obj: acess this.state.alreadyLogged 
 */
export async function checkLogin(obj) {
    var lEmail = sessionStorage.getItem(inEMAIL);
    var lPass = sessionStorage.getItem(inPASSWORD);

    if (lEmail !== null && lPass !== null) {

        obj.setState({ alreadyLogged: 'loading' });
        sessionStorage.removeItem(inEMAIL);
        sessionStorage.removeItem(inPASSWORD);

        await Axios.get(baseURL + `Login?email=${lEmail}&password=${lPass}`, baseConfig)
            .then(r => {
                if (r.data.result === 'user' || r.data.result === 'instructor' || r.data.result === 'settings') {
                    localStorage.setItem(sessionKEY, r.data.ssKey);
                    localStorage.setItem(sessionID, r.data.ssValue);
                    // localStorage.setItem(sessionTIME, JSON.parse(r.data.expire).toString());
                }
                else {
                    obj.setState({ alreadyLogged: null });
                }
            })
            .catch(() => {
                obj.setState({ alreadyLogged: errorAPI });
            });
    }
}


/** Changes the obj.state.alreadyLogged to the name a permission:
 * 'user', 'instructor', 'loading', 'error' or null.
 * 
 * @param obj: acess this.state.alreadyLogged 
 */
export async function checkAuthentication(obj) {
    var lSettings = sessionStorage.getItem(settingsVar);
    var kUid = localStorage.getItem(sessionKEY);
    var vUid = localStorage.getItem(sessionID);
    // var time = localStorage.getItem(sessionTIME);

    if (obj.state.alreadyLogged === 'loading' && lSettings === null && vUid !== null && kUid !== null) {

        await Axios.get(baseURL + `Authentication?${sessionKEY}=${kUid}&${sessionID}=${vUid}`, baseConfig)
            .then(r => {
                if (r.data.result === 'user' || r.data.result === 'instructor' || r.data.result === 'settings') {
                    obj.setState({ alreadyLogged: r.data.result });
                    obj.setState({ name: r.data.email });
                }
                else {
                    obj.setState({ alreadyLogged: null });
                    localStorage.removeItem(sessionKEY);
                    localStorage.removeItem(sessionID);
                    // localStorage.removeItem(sessionTIME);
                }
            })
            .catch(() => {
                obj.setState({ alreadyLogged: errorAPI });
            });
    }
    else {
//        obj.setState({ alreadyLogged: null });
//        localStorage.removeItem(sessionKEY);
//        localStorage.removeItem(sessionID);
//        // localStorage.removeItem(sessionTIME);
    }
}

// Validates da Authentication
export function validateAuth(obj, val) {
    if (obj.state.alreadyLogged === null) return <Redirect to={{ pathname: '/login' }} />;
    if (obj.state.alreadyLogged === 'loading') return loadingPage();
    if (obj.state.alreadyLogged === 'error') return errorPage();
    if (obj.state.alreadyLogged !== val) return <Redirect to={{ pathname: '/' + obj.state.alreadyLogged }} />;
}


// Vars register
const regEmail = 'email';
const regPass = 'pass';
const regRePass = 'repass';

export async function checkRegister(obj) {
    var lEmail = sessionStorage.getItem(regEmail);
    var lPass = sessionStorage.getItem(regPass);
    var lRePass = sessionStorage.getItem(regRePass);

    if (lEmail !== null && lPass !== null && lRePass !== null) {

        obj.setState({ alreadyLogged: 'loading' });
        sessionStorage.removeItem(regEmail);
        sessionStorage.removeItem(regPass);
        sessionStorage.removeItem(regRePass);

        await Axios.get(baseURL + `Register?email=${lEmail}&password=${lPass}`, baseConfig)
            .then(r => {
                if (r.data.result === 'login') {
                    obj.setState({ alreadyLogged: null });
                }
                else {
                    obj.setState({ alreadyLogged: 'signup' });
                }
            })
            .catch(() => {
                obj.setState({ alreadyLogged: errorAPI });
            });
    }
}

// Vars settings
const settingsVar = 'settings';
const emailSettings = "emailSett";
const passwordSettings = "passSett";
const usernameSettings = "nameSett";
const genderSettings = "genderSett";
const addressSettings = "addrSett";
const contactSettings = "contactSett";
const daySettings = "daySett";
const monthSettings = "monthSett";
const yearSettings = "yearSett";
const heightSettings = "heightSett";
const weightSettings = "weightSett";

export function varsSettings(email, pass, name, gender, address, contact, day, month, year, height, weight) {
    sessionStorage.setItem(settingsVar, 'change');
    sessionStorage.setItem(emailSettings, email);
    sessionStorage.setItem(passwordSettings, pass);
    sessionStorage.setItem(usernameSettings, name);
    sessionStorage.setItem(genderSettings, gender);
    sessionStorage.setItem(addressSettings, address);
    sessionStorage.setItem(contactSettings, contact);
    sessionStorage.setItem(daySettings, day);
    sessionStorage.setItem(monthSettings, month);
    sessionStorage.setItem(yearSettings, year);
    sessionStorage.setItem(heightSettings, height);
    sessionStorage.setItem(weightSettings, weight);
}

export async function checkSettings(obj) {
    var lSettings = sessionStorage.getItem(settingsVar);
    var lemail = sessionStorage.getItem(emailSettings);
    var lpass = sessionStorage.getItem(passwordSettings);
    var lname = sessionStorage.getItem(usernameSettings);
    var lgender = sessionStorage.getItem(genderSettings);
    var laddress = sessionStorage.getItem(addressSettings);
    var lcontact = sessionStorage.getItem(contactSettings);
    var lday = sessionStorage.getItem(daySettings);
    var lmonth = sessionStorage.getItem(monthSettings);
    var lyear = sessionStorage.getItem(yearSettings);
    var lheight = sessionStorage.getItem(heightSettings);
    var lweight = sessionStorage.getItem(weightSettings);
    
    var kUid = localStorage.getItem(sessionKEY);
    var vUid = localStorage.getItem(sessionID);

    if (lSettings !== null) {

        sessionStorage.removeItem(settingsVar);
        sessionStorage.removeItem(emailSettings);
        sessionStorage.removeItem(passwordSettings);
        sessionStorage.removeItem(usernameSettings);
        sessionStorage.removeItem(genderSettings);
        sessionStorage.removeItem(addressSettings);
        sessionStorage.removeItem(contactSettings);
        sessionStorage.removeItem(daySettings);
        sessionStorage.removeItem(monthSettings);
        sessionStorage.removeItem(yearSettings);
        sessionStorage.removeItem(heightSettings);
        sessionStorage.removeItem(weightSettings);
        
        obj.setState({ alreadyLogged: 'loading' });

        await Axios.get(baseURL 
                + `Settings?${sessionKEY}=${kUid}&${sessionID}=${vUid}&`
                + `${emailSettings}=${lemail}&`
                + `${passwordSettings}=${lpass}&`
                + `${usernameSettings}=${lname}&`
                + `${genderSettings}=${lgender}&`
                + `${addressSettings}=${laddress}&`
                + `${contactSettings}=${lcontact}&`
                + `${daySettings}=${lday}&`
                + `${monthSettings}=${lmonth}&`
                + `${yearSettings}=${lyear}&`
                + `${heightSettings}=${lheight}&`
                + `${weightSettings}=${lweight}`
                , baseConfig)
            .then(r => {
                console.log(r);
                if (r.data.result === 'user') {
                    obj.setState({ alreadyLogged: r.data.result });
                }
                else {
                    obj.setState({ alreadyLogged: 'settings' });
                }
            })
            .catch(() => {
                obj.setState({ alreadyLogged: errorAPI });
            });
    }
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