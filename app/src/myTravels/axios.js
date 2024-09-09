import axios from "axios";

const instance = axios.create({
    baseURL: "https://localhost:4711/api/v0.1",
});

export default instance;