import axios from "axios";
const BASE_URL = 'https://localhost:4711/api/v0.1/travels?includeSubTravels=true';

export default axios.create({
    baseURL: BASE_URL,
    headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
        "Accept": "application/json"
    }
})