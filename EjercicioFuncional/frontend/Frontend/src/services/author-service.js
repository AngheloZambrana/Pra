import axios from "axios";

const API_URL = "http://localhost:5203/api/Author/";

export async function getAuthors() {
    try {
        const response = await axios.get(API_URL);
        return response.data;
    } catch (error) {
        throw new Error(error,"Error al obtener autores");
    }
}

export async function createAuthor(author) {
    try {
        const response = await axios.post(API_URL, author);
        return response.data;
    } catch (error) {
        throw new Error(error, "Error al crear autor");
    }
}

export async function getAuthorById(id) {
    const response = await fetch(`${API_URL}${id}`); // Usa template literals
    const data = await response.json();
    return data;
}

export async function deleteAuthor(id) {
    try {
        const response = await axios.delete(`${API_URL}${id}`);
        return response.data; // Devolver datos si es necesario
    } catch (error) {
        throw new Error("Error al eliminar autor: " + error);
    }
}

// Función para actualizar un autor
export async function updateAuthor(id, updatedAuthor) {
    try {
        const response = await axios.put(`${API_URL}${id}`, updatedAuthor); // O usa .patch si la API usa PATCH
        return response.data;
    } catch (error) {
        throw new Error("Error al actualizar autor: " + error);
    }
}