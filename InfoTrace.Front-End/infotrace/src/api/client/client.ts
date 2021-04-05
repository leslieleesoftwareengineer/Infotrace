import axios from "axios";

export const client = axios.create({
  baseURL: "http://localhost:7000/",
  timeout: 1000,
});
