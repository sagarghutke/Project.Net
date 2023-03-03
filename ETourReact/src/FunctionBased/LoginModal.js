import * as Yup from 'yup';
import { useState } from 'react';

const validationSchema = Yup.object().shape({
  username: Yup.string().required('Username is required'),
  password: Yup.string().required('Password is required'),
});

const LoginModal = () => {
  const [isOpen, setIsOpen] = useState(false);
  const [formValues, setFormValues] = useState({
    username: '',
    password: '',
  });
  const [formErrors, setFormErrors] = useState({});
  const [isSubmitting, setIsSubmitting] = useState(false);

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormValues({ ...formValues, [name]: value });
  };

  const handleFormSubmit = async (event) => {
    event.preventDefault();
    setIsSubmitting(true);

    try {
      await validationSchema.validate(formValues, { abortEarly: false });
      // form is valid, do something here
      toggleModal();
    } catch (validationErrors) {
      const errors = {};
      validationErrors.inner.forEach((error) => {
        errors[error.path] = error.message;
      });
      setFormErrors(errors);
    } finally {
      setIsSubmitting(false);
    }
  };

  const toggleModal = () => {
    setIsOpen(true);
  };

  return (
    <>
      <button onClick={toggleModal}>Log In</button>
      {isOpen && (
        <div className="modal">
          <div className="modal-content">
            <span className="close" onClick={toggleModal}>&times;</span>
            <form onSubmit={handleFormSubmit}>
              <div>
                <label htmlFor="username">Username</label>
                <input
                  type="text"
                  name="username"
                  value={formValues.username}
                  onChange={handleInputChange}
                />
                {formErrors.username && <span>{formErrors.username}</span>}
              </div>
              <div>
                <label htmlFor="password">Password</label>
                <input
                  type="password"
                  name="password"
                  value={formValues.password}
                  onChange={handleInputChange}
                />
                {formErrors.password && <span>{formErrors.password}</span>}
              </div>
              <button type="submit" disabled={isSubmitting}>
                {isSubmitting ? 'Logging in...' : 'Log In'}
              </button>
            </form>
          </div>
        </div>
      )}
    </>
  );
};
export default LoginModal;