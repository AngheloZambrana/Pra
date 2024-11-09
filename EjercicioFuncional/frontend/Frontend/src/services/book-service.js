import axios from "axios";

const API_URL = "http://localhost:5203/api/Book/";

export async function getBooks() {
    const response = await axios.get(API_URL);
    return response.data;
}

export async function getBookById(id) {
    const response = await axios.get(`${API_URL}${id}`);
    return response.data;
}

export async function createBook(book) {
    const response = await axios.post(API_URL, book);
    return response.data;
}

export async function updateBook(id, book) {
    const response = await axios.put(`${API_URL}${id}`, book);
    return response.data;
}

export async function deleteBook(id) {
    await axios.delete(`${API_URL}${id}`);
}
