import { useEffect, useState } from 'react';
import axios from 'axios';
import "./RequestLogs.css";
import LogEntry from "./LogEntry";
import Loading from "../Loading";

function RequestLogs() {
    const [logs, setLogs] = useState([]);

    useEffect(() => {
        fetchRequestLogs();

        const intervalId = setInterval(() => {
            fetchRequestLogs();
        }, 60000);

        return () => clearInterval(intervalId);
    }, []);


    return (
        <div>
            {logs.length > 0 ?
                <div className="request_logs">
                    <h2>Request logs (last 100)</h2>
                    <table className="log-table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Method</th>
                                <th>Status</th>
                                <th>Success</th>
                                <th>Timestamp</th>
                                <th>Request URL</th>
                                <th>Error Message</th>
                            </tr>
                        </thead>
                        <tbody>
                            {logs.map((log) => (
                                <LogEntry log={log} />
                            ))}
                        </tbody>
                    </table>
                </div>
                :
                <Loading message={"Loading..."} />
            }
            
        </div>
    );

    async function fetchRequestLogs() {
        const response = await axios.get('api/weatherreports/logs');
        setLogs(response.data);
    }
}

export default RequestLogs;