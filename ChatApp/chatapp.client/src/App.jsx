import { useEffect, useState } from 'react';
import * as signalR from '@Microsoft/signalr';

function App() {
    const [message, setMessage] = useState('');

    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
        connection.start().then(() => console.log('Connection started')).catch((err) => console.log('Error while establishing connection :('));
        connection.on("ReceiveMessage", (message) => { setMessage(message) });

    }, []);



    return (
        <div>
            <p>Message From server: {message}</p>
        </div>
    );


}

export default App;