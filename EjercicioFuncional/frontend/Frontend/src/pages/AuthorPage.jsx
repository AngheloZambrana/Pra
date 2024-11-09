import { useEffect, useState } from "react";
import { getAuthors, createAuthor, getAuthorById, deleteAuthor, updateAuthor } from "../services/author-service";
import InputField from "../components/InputField";
import { Formik, Form } from "formik";
import { useNavigate } from 'react-router-dom';  // Importar useNavigate para la redirección
//import '../App.css';

export default function AuthorsPage() {
    const [authors, setAuthors] = useState([]);
    const [searchedAuthor, setSearchedAuthor] = useState(null);
    const [editingAuthor, setEditingAuthor] = useState(null);

    const navigate = useNavigate(); // Crear la instancia de navigate

    useEffect(() => {
        fetchAuthors();
    }, []);

    async function fetchAuthors() {
        const authorsData = await getAuthors();
        setAuthors(authorsData);
    }

    async function fetchAuthorById(id) {
        const authorData = await getAuthorById(id);
        setSearchedAuthor(authorData);
    }

    async function handleDelete(id) {
        try {
            await deleteAuthor(id); 
            fetchAuthors(); 
        } catch (error) {
            console.error("Error al eliminar autor", error);
        }
    }

    async function handleUpdate(id, updatedAuthor) {
        try {
            await updateAuthor(id, updatedAuthor); // Llamar a la función update
            fetchAuthors(); // Recargar la lista de autores después de la actualización
            setEditingAuthor(null); // Cerrar el formulario de edición
        } catch (error) {
            console.error("Error al actualizar autor", error);
        }
    }

    // Función para redirigir a la página BooksPage
    function redirectToBooksPage() {
        navigate('/books'); // Aquí '/books' debe coincidir con la ruta que configuraste para BooksPage
    }

    return (
        <div>
            <h1>Autores</h1>
            <ul>
                {authors.map(author => (
                    <li key={author.id}>
                        {author.name} {author.surname} {author.nationality}
                        <button onClick={() => handleDelete(author.id)}>Eliminar</button>
                        <button onClick={() => setEditingAuthor(author)}>Editar</button>
                    </li>
                ))}
            </ul>

            <h2>Agregar Nuevo Autor</h2>
            <Formik
                initialValues={{ name: "", surname: "", nationality: "" }}
                onSubmit={async (values, { resetForm }) => {
                    await createAuthor(values);
                    fetchAuthors();
                    resetForm();
                }}
            >
                {() => (
                    <Form>
                        <InputField name="name" type="text" text="Nombre" placeholder="Nombre" />
                        <InputField name="surname" type="text" text="Apellido" placeholder="Apellido" />
                        <InputField name="nationality" type="text" text="Nacionalidad" placeholder="Nacionalidad" />
                        <button type="submit">Agregar Autor</button>
                    </Form>
                )}
            </Formik>

            <h2>Buscar Autor por ID</h2>
            <Formik
                initialValues={{ id: "" }}
                onSubmit={async (values) => {
                    await fetchAuthorById(values.id);
                }}
            >
                {() => (
                    <Form>
                        <InputField name="id" type="text" text="ID del Autor" placeholder="Ingrese el ID" />
                        <button type="submit">Buscar Autor</button>
                    </Form>
                )}
            </Formik>

            {searchedAuthor && (
                <div>
                    <h3>Información del Autor:</h3>
                    <p><strong>Nombre:</strong> {searchedAuthor.name}</p>
                    <p><strong>Apellido:</strong> {searchedAuthor.surname}</p>
                    <p><strong>Nacionalidad:</strong> {searchedAuthor.nationality}</p>
                </div>
            )}

            {/* Formulario de Edición */}
            {editingAuthor && (
                <div>
                    <h2>Editar Autor</h2>
                    <Formik
                        initialValues={{
                            name: editingAuthor.name,
                            surname: editingAuthor.surname,
                            nationality: editingAuthor.nationality
                        }}
                        onSubmit={async (values) => {
                            await handleUpdate(editingAuthor.id, values);
                        }}
                    >
                        {() => (
                            <Form>
                                <InputField name="name" type="text" text="Nombre" placeholder="Nombre" />
                                <InputField name="surname" type="text" text="Apellido" placeholder="Apellido" />
                                <InputField name="nationality" type="text" text="Nacionalidad" placeholder="Nacionalidad" />
                                <button type="submit">Actualizar Autor</button>
                                <button type="button" onClick={() => setEditingAuthor(null)}>Cancelar</button>
                            </Form>
                        )}
                    </Formik>
                </div>
            )}

            {/* Botón para redirigir a la página de libros */}
            <button onClick={redirectToBooksPage}>Ir a Libros</button>
        </div>
    );
}
