CREATE TABLE department (
  id SERIAL PRIMARY KEY,
  name TEXT
);

CREATE TABLE students (
  id SERIAL PRIMARY KEY,
  department_id INT NULL,
  name VARCHAR(100),
  surname VARCHAR(100),
  CONSTRAINT fk_department FOREIGN KEY (department_id) REFERENCES department (id)
);

CREATE TABLE courses (
  id SERIAL PRIMARY KEY,
  name TEXT
);

CREATE TABLE courses_student (
  courses_id INT,
  student_id INT,
  PRIMARY KEY (courses_id, student_id),
  CONSTRAINT fk_courses FOREIGN KEY (courses_id) REFERENCES courses (id),
  CONSTRAINT fk_student FOREIGN KEY (student_id) REFERENCES students (id)
);

CREATE TABLE department_course (
  department_id INT,
  courses_id INT,
  PRIMARY KEY (department_id, courses_id),
  CONSTRAINT fk_department_course FOREIGN KEY (courses_id) REFERENCES courses (id),
  CONSTRAINT fk_courses_department FOREIGN KEY (department_id) REFERENCES department (id)
);
