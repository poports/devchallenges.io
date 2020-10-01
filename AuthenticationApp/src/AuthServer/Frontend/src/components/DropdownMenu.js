import React, { useRef } from 'react'
import tw, { styled } from 'twin.macro'
import useToggleMenu from './../hooks/useToggleMenu'

import kermit from './../images/kermit.jpg'

const NavItemContainer = tw.div`flex relative inline-block float-right`
const Container = tw.div`relative text-sm`
const Image = tw.img`h-8 w-8 rounded-full border-gray-500 mr-2`
const Button = styled.button`
  ${tw`flex items-center mr-3 bg-transparent border-0 rounded
        hover:bg-gray-200 focus:outline-none text-gray-800 
        text-sm md:text-base font-bold py-2 px-4 cursor-pointer`}
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
const MenuLink = tw.a`px-4 py-2 block hover:bg-gray-400 no-underline hover:no-underline`
const Line = tw.hr`bg-gray-300 border-0 h-px`

export default () => {
  const ref = useRef()
  const { invisible, toggleMenu } = useToggleMenu(ref)

  return (
    <NavItemContainer>
      <Container>
        <Button onClick={toggleMenu}>
          <Image src={kermit}></Image>
          Kermit
          {/* prettier-ignore */}
          <svg version="1.1" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 129 129"  enableBackground="new 0 0 129 129">
            <g>
                <path d="m121.3,34.6c-1.6-1.6-4.2-1.6-5.8,0l-51,51.1-51.1-51.1c-1.6-1.6-4.2-1.6-5.8,0-1.6,1.6-1.6,4.2 0,5.8l53.9,53.9c0.8,0.8 1.8,1.2 2.9,1.2 1,0 2.1-0.4 2.9-1.2l53.9-53.9c1.7-1.6 1.7-4.2 0.1-5.8z" />
            </g>
        </svg>
        </Button>

        <Menu invisible={invisible} ref={ref}>
          <MenuItems>
            <MenuItem>
              <MenuLink onClick={toggleMenu} href="#">
                My Profile
              </MenuLink>
            </MenuItem>
            <MenuItem>
              <MenuLink onClick={toggleMenu} href="#">
                Group Chat
              </MenuLink>
            </MenuItem>
            <MenuItem>
              <Line />
            </MenuItem>
            <MenuItem>
              <MenuLink onClick={toggleMenu} href="#">
                Logout
              </MenuLink>
            </MenuItem>
          </MenuItems>
        </Menu>
      </Container>
    </NavItemContainer>
  )
}
