import React, { useState, useEffect, ChangeEvent, KeyboardEvent } from 'react';
import List from './components/List';
import Footer from './components/Footer';
import './App.css';
import './index.css';
import { v4 as uuid } from 'uuid';

function App() {
  const [todos, setTodos] = useState(() => {
    const todo = localStorage.getItem("todos");
    return todo ? JSON.parse(todo) : [];
  });

  useEffect(() => {
    localStorage.setItem("todos", JSON.stringify(todos));
  }, [todos]);

  const onChangeInput = (e: ChangeEvent<HTMLInputElement>) => {
    e.preventDefault();
  };

  const onKeyPress = (e: KeyboardEvent<HTMLInputElement>) => {
    if (e.key === "Enter") {
      e.preventDefault();
      setTodos([
        ...todos,
        { id: uuid(), content: e.currentTarget.value, isCompleted: false, editing: false }
      ]);
      e.currentTarget.value = "";
    }
  };

  const [toShow, setToShow] = useState("all");

  return (
    <>
      <section className="todoapp">
        <header className="header">
          <h1>todos</h1>
          <form onChange={() => onChangeInput} onSubmit={(e: React.FormEvent<HTMLFormElement>) => e.preventDefault()}>
            <input className="new-todo" placeholder="Add todo" autoFocus onKeyPress={onKeyPress} />
          </form>
        </header>
        <List todos={todos} setTodos={setTodos} toShow={toShow} />
        <Footer todos={todos} setTodos={setTodos} toShow={toShow} setToShow={setToShow} />
      </section>
    </>
  );
}

export default App;
