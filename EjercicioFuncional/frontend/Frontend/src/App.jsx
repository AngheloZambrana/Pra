import { Routes, Route} from 'react-router-dom'
import './App.css'
import AuthorsPage from './pages/AuthorPage'
import BooksPage from './pages/BooksPage.'
import Header from './components/Header'


function App() {

  return (
    <div>
      <Header />
        <Routes>
          <Route path="/authors" element={<AuthorsPage/>}/>
          <Route path="/books" element={<BooksPage/>}/>
        </Routes>
    </div>
  )
}

export default App
