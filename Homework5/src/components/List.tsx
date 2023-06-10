import React from 'react';
import ListItem from './ListItem';
import Todo from './todo';

interface ListProps {
  toShow: string;
  todos: Todo[];
  setTodos: React.Dispatch<React.SetStateAction<Todo[]>>;
}

const List: React.FC<ListProps> = ({ toShow, todos, setTodos }) => {
  const filtered = () => {
    if (toShow === "all") {
      return todos;
    } else if (toShow === "active") {
      return todos.filter((todo) => !todo.isCompleted);
    } else if (toShow === "completed") {
      return todos.filter((todo) => todo.isCompleted);
    }
    return [];
  };

  const onClickDestroy = (id: number) => {
    setTodos([...todos].filter((todo) => todo.id !== id));
  };

  const onClickComplete = (id: number) => {
    setTodos(
      todos.map((todo) => {
        if (todo.id === id) {
          todo.isCompleted = !todo.isCompleted;
        }
        return todo;
      })
    );
  };

  const onClickMarkAll = () => {
    const allMarked = todos.every(todo => todo.isCompleted);
    setTodos(
      todos.map((todo) => ({
        ...todo,
        isCompleted: !allMarked,
      }))
    );
  };
  
  return (
    <>
      <section className="main">
        <input className="toggle-all" type="checkbox" />
        <label htmlFor="toggle-all" onClick={onClickMarkAll}>
          Mark all as complete
        </label>
        <ul className="todo-list">
          {filtered().map((todo) => (
            <li className={todo.isCompleted ? "completed" : ""} key={todo.id}>
              <div className="view">
                <input
                  onChange={() => onClickComplete(todo.id)}
                  className="toggle"
                  checked={todo.isCompleted}
                  type="checkbox"
                />
                <ListItem todos={todos} setTodos={setTodos} todo={todo} />
                <button
                  className="destroy"
                  onClick={() => onClickDestroy(todo.id)}
                />
              </div>
            </li>
          ))}
        </ul>
      </section>
    </>
  );
};

export default List;
