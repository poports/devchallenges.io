import React from 'react'
import { Redirect } from 'react-router-dom'
import { useAuth, signin } from './../hooks/use-auth'

const Login = () => {
  const auth = useAuth()

  return auth.user ? (
    <Redirect to={'/'} />
  ) : (
    <div>
      <button onClick={() => signin()}>Login</button>
    </div>
  )
}

export default Login
