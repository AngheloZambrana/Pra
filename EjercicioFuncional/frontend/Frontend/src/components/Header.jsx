import { Link } from "react-router-dom";

export default function Header() {
    return (
        <header>
            <nav>
                <ul>
                    <li><Link to="/authors">Authors</Link></li>
                    <li><Link to="/books">Libros</Link></li>
                </ul>
            </nav>
        </header>
    );
}
