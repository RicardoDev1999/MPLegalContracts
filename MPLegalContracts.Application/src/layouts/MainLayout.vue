<script setup></script>

<template>
  <header></header>
  <main class="flex flex-1 bg-slate-900 w-full min-h-dvh h-auto">
    <div
      class="flex flex-1 flex-col max-w-screen-xl lg:mx-20 md:mx-12 mx-10 pt-20"
    >
      <slot></slot>
    </div>
  </main>
  <footer></footer>
</template>
