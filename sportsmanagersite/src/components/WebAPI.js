
export const baseURL = 'https://localhost:44384'

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