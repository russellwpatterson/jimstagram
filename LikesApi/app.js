import express from 'express';
import { Client } from 'pg';
import jwt from 'express-jwt';

const JWT_SECRET = 'FsUbFd6ANLM6LyeMl3W0QnmhED4FP7ZXm6zyb9DcRfMg3CiVFY_Itddn4u_2hQgimRZt58hIVTIc_m919XajUg2u3JJRsGW_qv7FlB-Rtvm1yMTXfT' +
                   '0lfn91feuuzXjbx0Q7eEiHxlJIsAnkgE5ZaXvIDKhhesEBZNeU9LRitFoUKbhtB-jS7xWZ2BWPNloO4svA9tHD1FsZ8ovbzDoUmXvqtLJCz63k7UcB' +
                   'YY7qMlJJ4PrrkQKa5X6zR78utcxBTmAf2ocq4G0-1DOvyFTc7QoV29ozadFNOPGM6ulttePR0Dkr85S1LlMssjk6xon8Yytm_EvU35uy6ZsYseicOA';

const app = express();

app.get('/api/likes/jwtvalidate', jwt({ secret: JWT_SECRET }), (req, res) => {
    res.status(200).send("API is running. Valid JWT.");
});

app.get('/api/likes/', (req, res) => {
    res.status(200).send("API is running.");
});

app.post('/api/likes/:postId/sogood', jwt({ secret: JWT_SECRET }), async (req, res) => {
    const pgClient = new Client();
    let returnCode = 200;
    let returnMessage = "OK";

    try {
        await pgClient.connect();
        await pgClient.query(
            'UPDATE post ' +
            'SET so_goods = so_goods + 1 ' + 
            'WHERE id = $1::bigint', 
            [req.params.postId]
        );

    } catch (err) {
        returnCode = 500;
        returnMessage = err;
    } finally {
        await pgClient.end();
    }

    res.status(returnCode).send(returnMessage);
});

app.post('/api/likes/:postId/thatsdecent', jwt({ secret: JWT_SECRET }), async (req, res) => {
    const pgClient = new Client();
    let returnCode = 200;
    let returnMessage = "OK";

    try {
        await pgClient.connect();    
        await pgClient.query(
            'UPDATE post ' +
            'SET thats_decents = thats_decents + 1 ' + 
            'WHERE id = $1::bigint', 
            [req.params.postId]
        );

    } catch (err) {
        returnCode = 500;
        returnMessage = err;
    } finally {
        await pgClient.end();
    }

    res.status(returnCode).send(returnMessage);
});

app.post('/api/likes/:postId/notsogood', jwt({ secret: JWT_SECRET }), async (req, res) => {
    const pgClient = new Client();
    let returnCode = 200;
    let returnMessage = "OK";

    try {
        await pgClient.connect();
        await pgClient.query(
            'UPDATE post ' +
            'SET not_so_goods = not_so_goods + 1 ' + 
            'WHERE id = $1::bigint', 
            [req.params.postId]
        );

    } catch (err) {
        returnCode = 500;
        returnMessage = err;
    } finally {
        await pgClient.end();
    }

    res.status(returnCode).send(returnMessage);    
});

const PORT = process.env.JIMSTAGRAM_PORT || 5002;

app.listen(PORT, () => {
    console.log(`Server running on port ${PORT}`)
});
