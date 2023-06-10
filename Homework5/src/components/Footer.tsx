import React from 'react';

interface Todo {
  id: number;
  content: string;
  isCompleted: boolean;
}

interface FooterProps {
  todos: Todo[];
  setTodos: React.Dispatch<React.SetStateAction<Todo[]>>;
  toShow: string;
  setToShow: React.Dispatch<React.SetStateAction<string>>;
}

const Footer: React.FC<FooterProps> = ({ todos, setTodos, toShow, setToShow }) => {
  const onClickAll = (e: React.MouseEvent<HTMLAnchorElement>) => {
    setToShow('all');
    e.preventDefault();
  };

  const onClickActive = (e: React.MouseEvent<HTMLAnchorElement>) => {
    setToShow('active');
    e.preventDefault();
  };

  const onClickCompleted = (e: React.MouseEvent<HTMLAnchorElement>) => {
    setToShow('completed');
    e.preventDefault();
  };

  const onClickClearCompleted = () => {
    setTodos(todos.filter((todo) => !todo.isCompleted));
  };

  return (
    <>
      <footer className="footer">
        <span className="todo-count">
          <strong>{todos.filter((todo) => !todo.isCompleted).length}</strong> todos left
        </span>
        <ul className="filters">
          <li>
            <a
              className={toShow === 'all' ? 'selected' : ''}
              href="/"
              onClick={onClickAll}
            >
              All
            </a>
          </li>
          <li>
            <a
              className={toShow === 'active' ? 'selected' : ''}
              href="/"
              onClick={onClickActive}
            >
              Active
            </a>
          </li>
          <li>
            <a
              className={toShow === 'completed' ? 'selected' : ''}
              href="/"
              onClick={onClickCompleted}
            >
              Completed
            </a>
          </li>
        </ul>
        <button
          onClick={onClickClearCompleted}
          className="clear-completed"
        >
          Clear completed
        </button>
      </footer>
    </>
  );
};

export default Footer;
