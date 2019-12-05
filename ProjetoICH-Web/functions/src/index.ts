import * as functions from 'firebase-functions';
import { initializeApp } from 'firebase-admin';

// // Start writing Firebase Functions
// // https://firebase.google.com/docs/functions/typescript

initializeApp();
const admin = require("firebase-admin");
const firestore = admin.firestore();

export const uploadToDatabase = functions.https.onRequest(async (request, response) => {
    
    const data = JSON.parse(request.body)

    await firestore
        .collection("posts")
        .add(data)
    response.send("OKIDOKI")
})