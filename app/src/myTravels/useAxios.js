// Youtube: Use Axios with React Hooks for Async-Await Requests
// https://www.youtube.com/watch?v=NqdqnfzOQFE
import { useState, useEffect } from "react";

const useAxios = (config) => {
    const {
        axiosInstance,
        method,
        url,
        requestConfig = {}
    } = config;

    const [response, setResponse] = useState([]);
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const controller = new AbortController();
        const fetchData = async () => {
            try {
                const res = await axiosInstance[method.toLowerCase()](url, {
                    ...requestConfig,
                    signal: controller.signal
                })
                console.log(res);
                setResponse(res.data);
            } catch (err) {
                setError(err);
                console.log(err.message);
            } finally {
                setLoading(false);
            }
        }

        fetchData();

        // useEffect cleanup function
        return () => controller.abort();
    }, [])

    return [response, error, loading];
}

export default useAxios;