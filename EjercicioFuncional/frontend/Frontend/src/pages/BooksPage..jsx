import { useEffect, useState } from "react";
import { getBooks, createBook, updateBook, deleteBook } from "../services/book-service";
import { Formik, Field, Form } from 'formik';

export default function BooksPage() {
    const [books, setBooks] = useState([]);
    const [editingBook, setEditingBook] = useState(null);

    // Cargar libros al iniciar
    useEffect(() => {
        fetchBooks();
    }, []);

    async function fetchBooks() {
        const booksData = await getBooks();
        setBooks(booksData);
    }

    async function handleCreate(values) {
        await createBook(values);
        fetchBooks(); // Actualiza la lista de libros después de crear uno nuevo
    }

    async function handleEdit(values) {
        if (editingBook) {
            await updateBook(editingBook.id, values);
            setEditingBook(null);
            fetchBooks(); // Actualiza la lista después de editar
        }
    }

    async function handleDelete(id) {
        await deleteBook(id);
        fetchBooks(); // Actualiza la lista después de eliminar un libro
    }

    function startEdit(book) {
        setEditingBook(book);
    }

    return (
        <div>
            <h1>Libros</h1>
            <ul>
                {books.map(book => (
                    <li key={book.id}>
                        {book.title} ({book.id} )
                        <button onClick={() => startEdit(book)}>Editar</button>
                        <button onClick={() => handleDelete(book.id)}>Eliminar</button>
                    </li>
                ))}
            </ul>

            <h2>{editingBook ? "Editar Libro" : "Agregar Nuevo Libro"}</h2>

            <Formik
                initialValues={{
                    title: editingBook ? editingBook.title : '',
                    author: editingBook ? editingBook.author : '',
                    genre: editingBook ? editingBook.genre : ''
                }}
                onSubmit={(values) => {
                    editingBook ? handleEdit(values) : handleCreate(values);
                }}
            >
                {({ values, handleChange, handleBlur }) => (
                    <Form>
                        <Field
                            name="title"
                            type="text"
                            placeholder="Título"
                            onChange={handleChange}
                            onBlur={handleBlur}
                            value={values.title}
                        />
                        <Field
                            name="author"
                            type="text"
                            placeholder="Autor"
                            onChange={handleChange}
                            onBlur={handleBlur}
                            value={values.author}
                        />
                        <Field
                            name="genre"
                            type="text"
                            placeholder="Género"
                            onChange={handleChange}
                            onBlur={handleBlur}
                            value={values.genre}
                        />

                        <button type="submit">
                            {editingBook ? "Actualizar Libro" : "Agregar Libro"}
                        </button>
                        {editingBook && <button onClick={() => setEditingBook(null)}>Cancelar Edición</button>}
                    </Form>
                )}
            </Formik>
        </div>
    );
}
