import { useContext, useState, useEffect } from 'react'
import { UserContext } from './../App'

const useUserData = () => {
  const context = useContext(UserContext)

  const [user, setUser] = useState({
    name: null,
    token: null,
    authenticated: false
  })
  const [profileList, setProfileList] = useState([])
  const [photo, setPhoto] = useState(null)

  useEffect(() => {
    setUser({
      name: context.user,
      token: context.token,
      authenticated: context.isAuthenticated
    })

    //refactor later
    const fetchProfile = async () => {
      const response = await fetch('/api/profile', {
        headers: !user.token ? {} : { Authorization: `Bearer ${user.token}` }
      })
      const data = await response.json()
      setProfileList(data)
    }

    const fetchPhoto = async () => {
      const response = await fetch('/api/photo', {
        headers: !user.token ? {} : { Authorization: `Bearer ${user.token}` }
      })
      const data = await response.json()
      setPhoto(data.photo)
    }

    if (user.token) {
      fetchProfile()
      fetchPhoto()
    }
    //end refactor later
  }, [context, user.token])

  return { user, profileList, photo }
}

export default useUserData
