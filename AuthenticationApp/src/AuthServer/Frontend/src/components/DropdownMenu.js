import React, { useRef } from 'react'
import tw, { styled } from 'twin.macro'
import useToggleMenu from './../hooks/useToggleMenu'
import { Link } from 'react-router-dom'
import useUserData from './../hooks/useUserData'

const NavItemContainer = tw.div`flex relative inline-block float-right`
const Container = tw.div`relative text-sm`
const Image = tw.img`h-8 w-8 rounded border-gray-500 mr-2 object-cover`
const Button = styled.button`
  ${tw`flex items-center mr-3 bg-transparent border-0 rounded
        hover:bg-gray-200 focus:outline-none text-gray-800
        text-sm py-2 px-4 tracking-wider cursor-pointer`}
  svg {
    ${tw`pl-2 h-2 fill-current text-gray-500`}
  }
`
const Menu = styled.div(({ invisible }) => [
  tw`bg-white rounded shadow-md mt-2 mr-2 absolute mt-12 top-0 right-0 min-w-full overflow-auto z-30`,
  invisible && tw`invisible`
])

const MenuItems = tw.ul`list-none m-0 p-0`
const MenuItem = tw.li``
const Line = tw.hr`bg-gray-300 border-0 h-px`

// prettier - ignore
const StyledLink = styled(Link)(({ danger }) => [
  tw`px-4 py-2 block hover:bg-gray-400 no-underline hover:no-underline`,
  danger ? tw`text-red-500` : tw`text-gray-600`
])

export default () => {
  const ref = useRef()
  const { invisible, toggleMenu } = useToggleMenu(ref)
  const { user, photo } = useUserData()

  //console.log(photo)

  return (
    <NavItemContainer>
      <Container>
        <Button onClick={toggleMenu}>
          {photo && <Image src={photo} alt="Profile photo" />}
          {user.authenticated ? user.name : 'Account'}
          {/* prettier-ignore */}
          <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 129 129"><path d="M121.3 34.6c-1.6-1.6-4.2-1.6-5.8 0l-51 51.1-51.1-51.1c-1.6-1.6-4.2-1.6-5.8 0-1.6 1.6-1.6 4.2 0 5.8l53.9 53.9c.8.8 1.8 1.2 2.9 1.2 1 0 2.1-.4 2.9-1.2l53.9-53.9c1.7-1.6 1.7-4.2.1-5.8z"/></svg>
        </Button>

        <Menu invisible={invisible} ref={ref}>
          <MenuItems>
            {user.authenticated ? (
              <>
                <MenuItem>
                  <StyledLink onClick={toggleMenu} to="/profile">
                    My Profile
                  </StyledLink>
                </MenuItem>
                <MenuItem>
                  <StyledLink onClick={toggleMenu} to="/">
                    Group Chat
                  </StyledLink>
                </MenuItem>
                <MenuItem>
                  <Line />
                </MenuItem>
                <MenuItem>
                  <StyledLink
                    danger="true"
                    onClick={toggleMenu}
                    to="/authentication/logout"
                  >
                    Logout
                  </StyledLink>
                </MenuItem>
              </>
            ) : (
              <>
                <MenuItem>
                  <StyledLink onClick={toggleMenu} to="/authentication/login">
                    Login
                  </StyledLink>
                </MenuItem>
                <MenuItem>
                  <StyledLink
                    onClick={toggleMenu}
                    to="/authentication/register"
                  >
                    Register
                  </StyledLink>
                </MenuItem>
              </>
            )}
          </MenuItems>
        </Menu>
      </Container>
    </NavItemContainer>
  )
}
