import React from 'react'
import tw, { styled } from 'twin.macro'

const Sidebar = tw.aside`z-20 hidden w-64 overflow-y-auto bg-white md:block flex-shrink-0`
const Container = tw.div`py-4 text-gray-500`
const TitleLink = tw.a`ml-6 text-lg font-bold text-gray-800`
const List = tw.ul`mt-6`
const ListItem = tw.li`relative px-6 py-3`
const ListItemLink = styled.a`
  ${tw`inline-flex items-center w-full text-sm font-semibold transition-colors duration-150 hover:text-gray-800`}
  svg {
    ${tw`w-5 h-5`}
  }
`
const StyledListItemLink = styled(ListItemLink)(({ active }) => [
  active && tw`text-gray-800`
])
const ListItemActive = styled.span(({ active }) => [
  active
    ? tw`absolute inset-y-0 left-0 w-1 bg-purple-600 rounded-tr-lg rounded-br-lg`
    : tw`invisible`
])

const ListItemText = tw.span`ml-4`
const Backdrop = tw.div`fixed inset-0 z-10 flex items-end bg-black bg-opacity-50 sm:items-center sm:justify-center`

const Aside = () => {
  return (
    <Sidebar>
      <Container>
        <TitleLink href="#">Channels</TitleLink>
        <List>
          <ListItem>
            <ListItemActive aria-hidden="true" active="true" />
            <StyledListItemLink active="true" href="#">
              {/* prettier-ignore */}
              <svg class="w-5 h-5" aria-hidden="true" fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" viewBox="0 0 24 24" stroke="currentColor"><path d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"/></svg>
              <ListItemText>Dashboard</ListItemText>
            </StyledListItemLink>
          </ListItem>
          <ListItem>
            <StyledListItemLink href="#">
              {/* prettier-ignore */}
              <svg class="w-5 h-5" aria-hidden="true" fill="none" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" viewBox="0 0 24 24" stroke="currentColor"><path d="M3 12l2-2m0 0l7-7 7 7M5 10v10a1 1 0 001 1h3m10-11l2 2m-2-2v10a1 1 0 01-1 1h-3m-6 0a1 1 0 001-1v-4a1 1 0 011-1h2a1 1 0 011 1v4a1 1 0 001 1m-6 0h6"/></svg>
              <ListItemText>Dashboard</ListItemText>
            </StyledListItemLink>
          </ListItem>
        </List>
      </Container>
    </Sidebar>
  )
}

export default Aside
