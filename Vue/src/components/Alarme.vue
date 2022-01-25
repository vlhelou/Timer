<template>
  
  
<audio id="audio-player">
  <source src="@/assets/Toque.mp3" type="audio/mpeg">
  Your browser does not support the audio tag.
</audio>

  <button v-on:click="tocaAlarme()">dispara o alarme</button>
  <div class="row">
    <div class="col-12">
      <h3>Lista de Alarmes</h3>
      <table class="table table-bordered">
        <thead>
          <th>Alarme</th>
          <th>Duração</th>
          <th>Situação</th>
          <th>Próxima Execução</th>
          <th>Ação</th>
          <th>faltam (seq)</th>
        </thead>
        <tbody>
          <tr v-for="(alarme, index) in alarmes" :key="index">
            <td>{{ alarme.nome }}</td>
            <td class="text-end">{{ alarme.duracao }}</td>
            <td>{{ alarme.ativo }}</td>
            <td>{{ alarme.proximaExecucao }}</td>
            <td>
              <button
                class="btn btn-primary"
                v-if="!alarme.ativo"
                v-on:click="ativa(alarme)"
              >
                Inicia
              </button>
              <button
                class="btn btn-danger"
                v-if="alarme.ativo"
                v-on:click="desativa(alarme)"
              >
                Para
              </button>
            </td>
            <td>{{ alarme.remanescente }}</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>
<script>
export default {
  data() {
    return {
      alarmes: [
        {
          nome: "alarme teste",
          duracao: 10,
          ativo: false,
          remanescente: null,
          proximaExecucao: null,
        },
        {
          nome: "alarme 5 Min",
          duracao: 300,
          ativo: false,
          remanescente: null,
          proximaExecucao: null,
        },
        {
          nome: "alarme 15 Min",
          duracao: 900,
          ativo: false,
          remanescente: null,
          proximaExecucao: null,
        },
        {
          nome: "alarme 4",
          duracao: 300,
          ativo: false,
          remanescente: null,
          proximaExecucao: null,
        },
      ],
    };
  },
  created: function () {
    this.verificaAlarmes();
  },
  methods: {
    ativa(item) {
      item.proximaExecucao = new Date();
      item.proximaExecucao.setSeconds(
        item.proximaExecucao.getSeconds() + item.duracao
      );
      item.ativo = true;
    },
    desativa(item) {
      item.ativo = false;
      item.proximaExecucao = null;
      item.remanescente = null;
    },
    verificaAlarmes() {
      setTimeout(() => {
        const agora = new Date();
        const ativos = this.alarmes.filter((alrm) => alrm.ativo);
        ativos.map((atv) => {
          atv.remanescente = Math.round(
            (atv.proximaExecucao.getTime() - agora.getTime()) / 1000
          );
          if (atv.remanescente <= 0) {
            this.tocaAlarme();
            atv.proximaExecucao.setSeconds(
              atv.proximaExecucao.getSeconds() + atv.duracao
            );
          }
          // console.log(atv);
        });
        // console.log(`passei pelo timeout ${agora}`);
        this.verificaAlarmes();
      }, 1000);
    },
    tocaAlarme() {
      var el = document.getElementById("audio-player");
      el.load();
      el.play();
    },
  },
};
</script>
