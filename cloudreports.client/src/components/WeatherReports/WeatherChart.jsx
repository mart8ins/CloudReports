import React from "react";
import {
    LineChart,
    Line,
    XAxis,
    YAxis,
    CartesianGrid,
    Tooltip,
    Legend
} from "recharts";

export default function WeatherChart({ data, avarages }) {
    let min = avarages ? "Avarage min." : "Min.";
    let max = avarages ? "Avarage max." : "Max.";
    let cur = avarages ? "Avarage current" : "Current";

    return (
        <div>
            <LineChart width={700} height={400} data={data}>
                <XAxis dataKey="city" />
                <YAxis unit=" C" />
                <Tooltip />
                <Legend />
                <Line type="monotone" dataKey="tempMin" stroke="#2833de" name={min} />
                <Line type="monotone" dataKey="tempMax" stroke="#f6281b" name={max} />
                <Line type="monotone" dataKey="temperature" stroke="#61c210" name={cur} />
            </LineChart>
        </div>
    );
}
